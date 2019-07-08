using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyDiaryApp.Models;
using MyDiaryApp.GateWay;

namespace MyDiaryApp.Manager
{
    public class UserManager
    {
        UserGateWay userGateWay = new UserGateWay();

        public string SaveUser(User user)
        {
            if (userGateWay.SaveUser(user) > 0)
            {
                return "Saved successfully!!";
            }
            return "Don't Save!";
        }

        public bool IsEmailExist(string email)
        {
            bool isExist = userGateWay.IsEmailExist(email);
            return isExist;
        }

        public bool CheckEmailForForgetPassword(string email, int userId)
        {
            return userGateWay.CheckEmailForForgetPassword(email, userId);
        }

        public bool CheckPhoneNoForForgetPassword(string contactNo, int userId)
        {
            return userGateWay.CheckPhoneNoForForgetPassword(contactNo, userId);
        }

        public string GetContactNo(int userId)
        {
            return userGateWay.GetContactNo(userId);
        }
        public int UpdatePasswordForForgetPassword(string password, int userId)
        {
            return userGateWay.UpdatePasswordForForgetPassword(password,userId);
        }
        public bool CheckOldPassword(string password, int userId)
        {
            return userGateWay.CheckOldPassword(password,userId);
        }
    }
}