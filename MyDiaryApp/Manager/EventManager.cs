using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyDiaryApp.Models;
using MyDiaryApp.GateWay;

namespace MyDiaryApp.Manager
{
    
    public class EventManager
    {
        EventGateWay eventGateWay = new EventGateWay();

        public string SaveEvent(Event evnt)
        {
            if (eventGateWay.SaveEvent(evnt) > 0)
            {
                return "Saved";
            }
            return "Don't save";
        }


        //ShowEvent
        public List<Event> ShowEvent()
        {
            return (eventGateWay.ShowEvents());
        }

        public Event EditEvent(int eventId)
        {
            return eventGateWay.EditEvent(eventId);
        }

        public int SaveEditEvent(Event evnt)
        {
            return eventGateWay.SaveEditEvent(evnt);
        }

        public int DeleteEvent(int id)
        {
            return eventGateWay.DeleteEvent(id);
        }

        public Event DetailsEvent(int id)
        {
            return eventGateWay.DetailsEvent(Convert.ToInt32(id));
        }
    }
}