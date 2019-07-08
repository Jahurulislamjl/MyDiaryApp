using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using MyDiaryApp.Models;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Twilio.TwiML;


namespace MyDiaryApp.GateWay
{
    public class NotificationGateWay : DBConnection
    {
        public List<Event> GetEventForNotification()
        {
           
            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.Month.ToString();
            string day = DateTime.Now.Day.ToString();
            int yearInt = Convert.ToInt32(year);
            int monthInt = Convert.ToInt32(month);
            int dayInt = Convert.ToInt32(day);
            

            List<Event> eventsList=new List<Event>();
            Query = "select * from EventTl where year(ReminderDate)='" + yearInt + "' and month(ReminderDate)='" +
                    monthInt + "'  and day(ReminderDate)='" + dayInt + "' and DATEPART(Hour, [ReminderTime])='" + DateTime.Now.TimeOfDay.Hours+ "' and DATEPART(Minute, [ReminderTime])='" + DateTime.Now.TimeOfDay.Minutes + "' and NotificationStatus='0'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();

            while (Reader.Read())
            {
                Event events = new Event();
                events.EventId = (int)Reader["EventId"];
                events.UserId = (int)Reader["UserId"];
                events.EventDate = Reader["EventDate"].ToString();
                events.EventTime = Reader["EventTime"].ToString();
                events.EventDescription = Reader["EventDescription"].ToString();
                eventsList.Add(events);
            }
            Reader.Close();
            Connection.Close();
            return eventsList;
        }

        public int SaveEditEvent(int eventId)
        {

            Query = "Update EventTl set NotificationStatus='"+1+"' where EventId='"+eventId+"'";
           
            Command = new SqlCommand(Query, Connection);
            if (Connection.State == ConnectionState.Open)
            {
             Connection.Close();   
            }
            Connection.Open();
            Count = Command.ExecuteNonQuery();
            Connection.Close();
            return Count;
        }

        public string GetPhoneNumberById(int userId)
        {
            User user = new User();

            Query = "Select ContactNo from UserTB where UserId='"+userId+"'";
            Command=new SqlCommand(Query,Connection);
            if (Connection.State == ConnectionState.Open)
            {
                Connection.Close();
            }
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                user.ContactNo = Reader["ContactNo"].ToString();

            }
            Reader.Close();
            Connection.Close();
            return user.ContactNo;
        }

        public int SendNotificationToPhone(string phone,string messages)
        {
            try
            {
                const string accountSid = "AC4fffebf410feb04cc5996ea88dbcfb16";
                const string authToken = "d36254cedef14c4cc322620de13028fd";

                TwilioClient.Init(accountSid, authToken);

                var message = MessageResource.Create(
                    body: messages,
                    from: new Twilio.Types.PhoneNumber("+15852995984"),
                    to: new Twilio.Types.PhoneNumber("+88"+phone)
                );
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
            

        }
    }
}