using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyDiaryApp.Models;
using MyDiaryApp.Manager;
using MyDiaryApp.GateWay;

namespace MyDiaryApp.Controllers
{
    public class UserController : Controller
    {
        UserManager userManager = new UserManager();
        NotificationGateWay notificationGateway = new NotificationGateWay();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult UserRegistration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserRegistration(User user)
        {
            ViewBag.Message = userManager.SaveUser(user);
            ModelState.Clear();
            return View();
        }


        [AllowAnonymous]
        [HttpPost]
        public ActionResult IsEmailExist(string email)
        {
            bool check = userManager.IsEmailExist(email);
            return Json(check);
        }

        [HttpGet]
        public ActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgetPassword(string phoneOrEmail)
        {
            if (userManager.CheckEmailForForgetPassword(phoneOrEmail,1004) || userManager.CheckPhoneNoForForgetPassword(phoneOrEmail,1004))
            {
                Random random = new Random();
              int password=random.Next(1001,9999);
              string contactNo= userManager.GetContactNo(1004);
              if(notificationGateway.SendNotificationToPhone(contactNo, password.ToString())==1)
                {
                    userManager.UpdatePasswordForForgetPassword(password.ToString(),1004);
                }


            }
            return View("ChangePassword");
        }

        [HttpGet]
        public ActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(User user,string oldPassword)
        {
            if (userManager.CheckOldPassword(oldPassword, 1004))
            {
               if(userManager.UpdatePasswordForForgetPassword(user.Password, 1004)==1)
                {
                    ViewBag.Message = "Successfuly Changed password";
                }
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid Old Password";
            }
            return View();
        }


        public JsonResult CheckPhone(string contactNo)
        {
            if (contactNo.StartsWith("01"))
            {
                return Json(true);
            }
            return Json("Only Bangladeshi no start'01'", JsonRequestBehavior.AllowGet);

        }

    }
}