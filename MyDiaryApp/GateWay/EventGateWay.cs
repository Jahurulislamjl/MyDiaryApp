using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyDiaryApp.Models;
using System.Data.SqlClient;

namespace MyDiaryApp.GateWay
{
    public class EventGateWay : DBConnection
    {
        public int SaveEvent(Event evnt)
        {
            evnt.CreatedDateTime = DateTime.Now.ToString();
            try
            {
                Query ="Insert into EventTl(UserId,CreatedDateTime,EventDate,EventTime,ReminderDate,ReminderTime,EventDescription,NotificationStatus)Values(@UserId,@CreatedDateTime,@EventDate,@EventTime,@ReminderDate,@ReminderTime,@EventDescription,@NotificationStatus)";
                Command = new SqlCommand(Query, Connection);
                Command.Parameters.Clear();
                Connection.Open();


                Command.Parameters.AddWithValue("@UserId", evnt.UserId);
                Command.Parameters.AddWithValue("@CreatedDateTime", evnt.CreatedDateTime);
                Command.Parameters.AddWithValue("@EventDate", evnt.EventDate);
                Command.Parameters.AddWithValue("@EventTime", evnt.EventTime);
                Command.Parameters.AddWithValue("@ReminderDate", evnt.ReminderDate);
                Command.Parameters.AddWithValue("@ReminderTime", evnt.ReminderTime);
                Command.Parameters.AddWithValue("@EventDescription", evnt.EventDescription);
                Command.Parameters.AddWithValue("@NotificationStatus", evnt.NotificationStatus);

                Count = Command.ExecuteNonQuery();
                Connection.Close();
            }
            catch (Exception)
            {
                
            }

            return Count;

        }



        //ShowEvent
        public List<Event> ShowEvents()
        {
            List<Event> eventlist=new List<Event>();
            try
            {

            Query = "Select * From EventTl where UserId='" + 1004 + "' Order by CreatedDateTime ASC ";
            Command=new SqlCommand(Query,Connection);
            Connection.Open();
            SqlDataReader Reader = Command.ExecuteReader();

            while (Reader.Read())
            {
                Event events = new Event();
                events.EventId =(int) Reader["EventId"];
                events.CreatedDateTime = Reader["CreatedDateTime"].ToString();
                events.EventDate = Reader["EventDate"].ToString();
                events.EventTime = Reader["EventTime"].ToString();
                events.EventDescription = Reader["EventDescription"].ToString();

                eventlist.Add(events);
            }
            Reader.Close();
            Connection.Close();

            }
            catch (Exception)
            {

                
            }
            return eventlist;
        }

        public Event EditEvent(int eventId)
        {
            Event events=new Event();
            try
            {
                Query = "Select * from EventTl where EventId='" + eventId + "'";
                Command = new SqlCommand(Query, Connection);
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                while (Reader.Read())
                {
                    events.EventId = (int) Reader["EventId"];
                    events.EventDate = Reader["EventDate"].ToString();
                    events.EventTime = Reader["EventTime"].ToString();
                    events.ReminderDate = Reader["ReminderDate"].ToString();
                    events.ReminderTime = Reader["ReminderTime"].ToString();
                    events.EventDescription = Reader["EventDescription"].ToString();
                }
                Reader.Close();
                Connection.Close();
            }
            catch (Exception)
            {
                
            }
            return events;

        }

        public int SaveEditEvent(Event evnt)
        {
            Query = "Update EventTl set EventDate='"+evnt.EventDate+"', EventTime='"+evnt.EventTime+"', ReminderDate='"+evnt.ReminderDate+"', ReminderTime='"+evnt.ReminderTime+"', EventDescription='"+evnt.EventDescription+"' where EventId='"+evnt.EventId+"'";
            Command=new SqlCommand(Query,Connection);
            Connection.Open();
            Count = Command.ExecuteNonQuery();
            Connection.Close();
            return Count;
        }


        public int DeleteEvent(int id)
        {
            Query = "Delete from EventTl where EventId='"+id+"'";
            Command=new SqlCommand(Query,Connection);
            Connection.Open();
            Count = Command.ExecuteNonQuery();
            Connection.Close();
            return Count;
        }


        //DetailsEvent
        public Event DetailsEvent(int id)
        {
            Event events=new Event();
            Query="Select * from EventTl where EventId='"+id+"'";
            Command=new SqlCommand(Query,Connection);
            Connection.Open();
            SqlDataReader Reader = Command.ExecuteReader();

            while (Reader.Read())
            {
                events.EventId = (int)Reader["EventId"];
                events.CreatedDateTime = Reader["CreatedDateTime"].ToString();
                events.EventDate = Reader["EventDate"].ToString();
                events.EventTime = Reader["EventTime"].ToString();
                events.ReminderDate = Reader["ReminderDate"].ToString();
                events.ReminderTime = Reader["ReminderTime"].ToString();
                events.EventDescription = Reader["EventDescription"].ToString();
            }
            Reader.Close();
            Connection.Close();
            return events;

        }

       
    }
}