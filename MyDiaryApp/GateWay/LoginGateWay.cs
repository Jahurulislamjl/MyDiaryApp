using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using MyDiaryApp.Models;

namespace MyDiaryApp.GateWay
{
    public class LoginGateWay : DBConnection
    {
        public Login CheckUserForLogin(Login login)
        {
            
            Query = "Select * From LoginTB Where Email='" + login.Email + "' And Password='" + login.Password + "'";
            if (Connection.State == ConnectionState.Open)
            {
                Connection.Close();
            }
            Connection.Open();
            Command=new SqlCommand(Query, Connection);
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                login.LoginId = (int)Reader["LoginId"];
                login.Email = Reader["Email"].ToString();

            }
            Reader.Close();
            Connection.Close();
            return login;
        }
    }
}