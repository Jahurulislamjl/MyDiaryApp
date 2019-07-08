using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using MyDiaryApp.Models;
using MyDiaryApp.Manager;

namespace MyDiaryApp.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        LoginManager loginManager=new LoginManager();

        public ActionResult UserIndex()
        {
           if (Session["LoginId"] != null)
            {
                return View();
            }
           
                return RedirectToAction("Login", "Login");
            
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login login )
        {
            Login userLogin = loginManager.CheckUserForLogin(login);
            if (userLogin!=null)
            {

                Session["LoginId"] = userLogin.LoginId;
                Session["Email"] = userLogin.Email;
                //ViewBag.Message= "Succefully Login";
                return RedirectToAction("UserIndex");
                
            }
            else
            {
                ViewBag.ErrorMessage ="Invalid Email or password";
            }
           
            return View();
        }

        //Logout
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "Login");
        }
    }

}
