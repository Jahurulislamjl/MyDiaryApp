using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyDiaryApp.Models;
using MyDiaryApp.GateWay;

namespace MyDiaryApp.Manager
{
    public class LoginManager
    {
        
        LoginGateWay loginGateWay=new LoginGateWay();

        public Login CheckUserForLogin(Login login)
        {
            return loginGateWay.CheckUserForLogin(login);
        }


    }
}