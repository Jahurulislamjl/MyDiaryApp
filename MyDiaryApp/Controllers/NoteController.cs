using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyDiaryApp.Models;
using MyDiaryApp.Manager;

namespace MyDiaryApp.Controllers
{
    public class NoteController : Controller
    {
        NoteManager noteManager = new NoteManager();

        // GET: Note
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult NoteWrite()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult NoteWrite(Note note)
        {
            //note.UserId =Convert.ToInt32(Session["LoginId"]);
            note.UserId =(int) Session["LoginId"];
            ViewBag.Message = noteManager.SaveNote(note);
            ModelState.Clear();
            return View();
        }

        //ShowNotes
        public ActionResult ShowNotes()
        {
                return View(noteManager.ShowNotes());
           
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
       
            return View(noteManager.Edit(Convert.ToInt32(id)));
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit(Note note)
        {
            if (noteManager.SaveEdit(note) > 0)
            {
                ViewBag.SuccessMessage = "Successfully Updated";
            }
            else
            {
                ViewBag.ErrorMessage = "Updated failed";
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
       
            return View(noteManager.Edit(Convert.ToInt32(id)));
        }
        
        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (noteManager.Delete(id) > 0)
            {
                Session["SuccessMessage"] = "Successfully Deleted";
            }
            else
            {
                Session["ErrorMessage"]= "Deleted failed";
            }
            return RedirectToAction("ShowNotes");
        }
    }
}