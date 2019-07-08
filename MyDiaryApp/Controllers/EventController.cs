using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyDiaryApp.Models;
using MyDiaryApp.Manager;


namespace MyDiaryApp.Controllers
{
    public class EventController : Controller
    {
        EventManager eventManager = new EventManager();
        NotificationManager notificationManager=new NotificationManager();
        // GET: Event
        public ActionResult Index()
        {
            return View();
        }

       

        [HttpGet]
        public ActionResult CreateEvent()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreateEvent(Event aEvent)
        {
            aEvent.UserId = (int)Session["LoginId"];

            if (Convert.ToDateTime(aEvent.EventDate) < DateTime.Now)
            {
                ViewBag.ErrorMessage = "Error!Event Date less than Current date";
                return View();
            }
            if (Convert.ToDateTime(aEvent.EventDate) < Convert.ToDateTime(aEvent.ReminderDate))
            {
                ViewBag.ErrorMessage = "Error!Event Date   less than Reminder Date ";
                return View();
            }
            if (Convert.ToDateTime(aEvent.EventDate) == Convert.ToDateTime(aEvent.ReminderDate))
            {
                if (Convert.ToDateTime(aEvent.EventTime).Hour < Convert.ToDateTime(aEvent.ReminderTime).Hour)
                {
                    ViewBag.ErrorMessage = "Error!Event time less than Reminder time ";
                    return View();
                }

            }

            ViewBag.Message = eventManager.SaveEvent(aEvent);
            ModelState.Clear();
            return View();
        }

        [HttpGet]
        public ActionResult CreateEvents()
        {
            return View();
        }

  
        //ShowEvent
        public ActionResult ShowEvent()
        {
            return View(eventManager.ShowEvent());
        }

        [HttpGet]
        public ActionResult EditEvent(int? id)
        {
            return View(eventManager.EditEvent(Convert.ToInt32(id)));
        }

        [HttpPost]
        public ActionResult EditEvent(Event evnt)
        {
            if (eventManager.SaveEditEvent(evnt) > 0)
            {
                ViewBag.SuccessMessage = "Successfully Updated";
            }
            else
            {
                ViewBag.ErrorMessage = "Update failed";
            }
            return View();
        }

        [HttpGet]
        public ActionResult DeleteEvent(int? id)
        {
            return View(eventManager.EditEvent(Convert.ToInt32(id)));
        }

        [HttpPost]
        public ActionResult DeleteEvent(int id)
        {
            if (eventManager.DeleteEvent(id) > 0)
            {
                Session["SuccessMessage"] = "Successfully Deleted";
            }
            else
            {
                Session["ErrorMessage"] = "Deleted failed";
            }
            return RedirectToAction("ShowEvent");
        }


        public ActionResult DetailsEvent(int? id)
        {
            return View( eventManager.DetailsEvent(Convert.ToInt32(id)));
        }

        public void SendEventNotificationToPhone()
        {
            notificationManager.GetEventForNotification();
        }
    }
}