using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyDiaryApp.Models;
using System.Data.SqlClient;

namespace MyDiaryApp.GateWay
{
    public class UserGateWay : DBConnection
    {
        public int SaveUser(User user)
        {
            try
            {
                Query = "INSERT INTO UserTB(FirstName,LastName,DateOfBirth,Gender,ContactNo) Values(@FirstName,@LastName,@DateOfBirth,@Gender,@ContactNo) INSERT INTO LoginTB(Email,Password) VALUES(@Email, @Password) ";
                Command = new SqlCommand(Query, Connection);
                Command.Parameters.Clear();
                Connection.Open();

                Command.Parameters.AddWithValue("@FirstName", user.FirstName);
                Command.Parameters.AddWithValue("@LastName", user.LastName);
                Command.Parameters.AddWithValue("@DateOfBirth", user.DateOfBirth);
                Command.Parameters.AddWithValue("@Gender", user.Gender);
                Command.Parameters.AddWithValue("@ContactNo", user.ContactNo);
                Command.Parameters.AddWithValue("@Email", user.Email);
                Command.Parameters.AddWithValue("@Password", user.Password);

                Count = Command.ExecuteNonQuery();
                Connection.Close();
            }
            catch (Exception)
            {
                
            }
            return Count;
        }

        public bool CheckPhoneNoForForgetPassword(string contactNo, int userId)
        {
            if (Connection.State == System.Data.ConnectionState.Open)
            {
                Connection.Close();
            }
            Query = "Select * from UserTB where ContactNo='"+ contactNo + "' and UserId='"+userId+"'" ;
            Command = new SqlCommand(Query, Connection);
            Connection.Open();

            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                return true;
            }
            Reader.Close();
            Connection.Close();
            return false;

        }

        public bool IsEmailExist(string email)
        {
            try
            {
                Query = "SELECT Email FROM LoginTB WHERE Email=@Email";
                Command = new SqlCommand(Query, Connection);
                Command.Parameters.Clear();
                Connection.Open();
                Command.Parameters.AddWithValue("@Email", email);
                Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    return false;
                }
                Reader.Close();
                Connection.Close();
            }
            catch (Exception)
            {

            }
            return true;

        }

        public bool CheckEmailForForgetPassword(string email, int userId)
        {
            if (Connection.State == System.Data.ConnectionState.Open)
            {
                Connection.Close();
            }
            Query = "Select * from LoginTB where Email='" + email + "' and LoginId='" + userId + "'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();

            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                return true;
            }
            Reader.Close();
            Connection.Close();
            return false;

        }

        public string GetContactNo(int userId)
        {
            string contactNo="";
            
            Query = "Select ContactNo from UserTB where UserId='" + userId + "'";
            Command = new SqlCommand(Query, Connection);
            if (Connection.State == System.Data.ConnectionState.Open)
            {
                Connection.Close();
            }
            Connection.Open();
           

            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                contactNo = Reader["ContactNo"].ToString();   
            }
            Reader.Close();
            Connection.Close();
            return contactNo;

        }

        public int UpdatePasswordForForgetPassword(string password,int userId)
        {
            if (Connection.State == System.Data.ConnectionState.Open)
            {
                Connection.Close();
            }
            Query = "Update LoginTB set Password='"+password+"' where LoginId='"+userId+"'";
            Command = new SqlCommand(Query,Connection);
            Connection.Open();
            Count = Command.ExecuteNonQuery();
            Connection.Close();
            return Count;
        }

        public bool CheckOldPassword(string password, int userId)
        {
            if (Connection.State == System.Data.ConnectionState.Open)
            {
                Connection.Close();
            }
            Query = "Select * from LoginTB where Password='" + password + "' and LoginId='" + userId + "'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();

            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                return true;
            }
            Reader.Close();
            Connection.Close();
            return false;

        }
    }
}