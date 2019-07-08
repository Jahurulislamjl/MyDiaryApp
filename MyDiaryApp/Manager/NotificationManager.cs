using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyDiaryApp.Models;
using MyDiaryApp.GateWay;

namespace MyDiaryApp.Manager
{
    public class NotificationManager
    {
        NotificationGateWay notificationGateWay=new NotificationGateWay();
        public void GetEventForNotification()
        {
         List<Event> events=   notificationGateWay.GetEventForNotification();
            foreach (var aEvent in events)
            {
                string message = "Description:" + aEvent.EventDescription + "Date:" + aEvent.EventDate + "Time:" +
                                 aEvent.EventTime;
                notificationGateWay.SendNotificationToPhone(notificationGateWay.GetPhoneNumberById(aEvent.UserId),message);
                notificationGateWay.SaveEditEvent(aEvent.EventId);
            }
        }
    }
}