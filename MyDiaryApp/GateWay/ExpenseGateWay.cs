using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyDiaryApp.Models;
using System.Data.SqlClient;


namespace MyDiaryApp.GateWay
{
    public class ExpenseGateWay : DBConnection
    {
        public int SaveExpense(Expense expense)
        {
            Query = "Insert Into ExpenseTB(UserId,CreatedDate,ItemName,Amount) Values(@UserId,@CreatedDate,@ItemName,@Amount)";
            Command=new SqlCommand(Query,Connection);
            Command.Parameters.Clear();
            Connection.Open();

            Command.Parameters.AddWithValue("@UserId",expense.UserId);
            Command.Parameters.AddWithValue("@CreatedDate", DateTime.Now.ToString());
            Command.Parameters.AddWithValue("@ItemName", expense.ItemName);
            Command.Parameters.AddWithValue("@Amount", expense.Amount);

            Count = Command.ExecuteNonQuery();
            Connection.Close();
            return Count;


        }

        public List<Expense> ExpenseList(Expense expense)
        {
            //int year =Convert.ToInt32(Convert.ToDateTime(expense.CreatedDate).Year.ToString()); 
            //string month = Convert.ToDateTime(expense.CreatedDate).Month.ToString(); 
            //string day = Convert.ToDateTime(expense.CreatedDate).Day.ToString(); 
         
            int yearInt = Convert.ToInt32(Convert.ToDateTime(expense.CreatedDate).Year);
            int monthInt = Convert.ToInt32(Convert.ToDateTime(expense.CreatedDate).Month);
            int dayInt = Convert.ToInt32(Convert.ToDateTime(expense.CreatedDate).Day);
            List<Expense> expenses=new List<Expense>();
                Query = "Select * From ExpenseTB Where UserId='"+expense.UserId+ "' And Year(CreatedDate)='" + yearInt+ "' and Month(CreatedDate)='" + monthInt + "' and Day(CreatedDate)='" + dayInt + "'";
            Command=new SqlCommand(Query,Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                expense.ItemName = Reader["ItemName"].ToString();
                expense.Amount = Reader["Amount"].ToString();
                expenses.Add(expense);
            }
            Reader.Close();
            Connection.Close();
            return expenses;
        }

        ///////
        public List<Expense> YearExpenseList(Expense expense,int year)
        {

            List<Expense> expenses = new List<Expense>();
            Query = "Select * From ExpenseTB Where UserId='" + expense.UserId + "' And Year(CreatedDate)='" + year + "' ";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                expense.ItemName = Reader["ItemName"].ToString();
                expense.Amount = Reader["Amount"].ToString();
                expenses.Add(expense);
            }
            Reader.Close();
            Connection.Close();
            return expenses;
        }

        /////

        public List<Expense> MonthExpenseList(Expense expense,int month,int year)
        {

            List<Expense> expenses = new List<Expense>();
            Query = "Select * From ExpenseTB Where UserId='" + expense.UserId + "' And Year(CreatedDate)='" + year + "' and Month(CreatedDate)='" + month + "'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                expense.ItemName = Reader["ItemName"].ToString();
                expense.Amount = Reader["Amount"].ToString();
                expenses.Add(expense);
            }
            Reader.Close();
            Connection.Close();
            return expenses;
        }

    }
}