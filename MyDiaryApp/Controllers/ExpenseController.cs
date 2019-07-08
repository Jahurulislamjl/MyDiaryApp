using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyDiaryApp.Models;
using MyDiaryApp.GateWay;
using MyDiaryApp.Manager;
using System.Web.Security;
using Rotativa;
using Rotativa.MVC;

namespace MyDiaryApp.Controllers
{
    public class ExpenseController : Controller
    {
        ExpenseManager expenseManager = new ExpenseManager();
        // GET: Expense
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Expense(int? id)
        {
            if (id != null && Session["Expenses"] != null)
            {
                List<Expense> expenses =(List<Expense>) Session["Expenses"];
                foreach (var expense in expenses)
                {
                    expenseManager.SaveExpense(expense);
                }
            }
            Session["Expenses"] = null;
            Session["Amount"] = null;
            Session["Total"] = null;
            Session["Count"] = null;
            return View();
        }

        [HttpPost]
        public ActionResult Expense(Expense expense,int? id)
        {
            expense.UserId = (int)Session["LoginId"];

            List<Expense> expenses;
            if (Session["Expenses"] == null)
            {
                expenses=new List<Expense>();
                
            }
            else
            {
                expenses = (List<Expense>)Session["Expenses"];
            }
            
            expenses.Add(expense);
            Session["Expenses"]= expenses;
            ViewBag.Expenses = expenses;
            Session["Total"] = Convert.ToDouble(Session["Total"]) + Convert.ToDouble(expense.Amount);
            Session["Count"] = Convert.ToInt32(Session["Count"]) +1;
            ViewBag.Total = Session["Total"];
            ViewBag.Count = Session["Count"];
            return View();
        }

        public ActionResult ShowExpense()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ShowExpense(string date,int? month,int? year)
        {

            Session["Date"] = date;
          
            double Total=0;
           Expense expense=new Expense();
            List<Expense> expenses=null;
           
            expense.UserId = (int)Session["LoginId"];
            ViewBag.Count = 1;
            if (date != null)
            {
                expense.CreatedDate = date;
                expenses = expenseManager.ExpenseList(expense);
            }
            else if (month != null && year!=null)
            {
                expenses = expenseManager.MonthExpenseList(expense,(int)month,(int)year);
            }
            else
            {
                expenses = expenseManager.YearExpenseList(expense, (int)year);
            }

            foreach (var aExpense in expenses)
            {
                Total = Total +Convert.ToDouble(aExpense.Amount);
            }
            ViewBag.Total = Total;

            return View(expenses);
        }

        
        [HttpGet]
        public ActionResult ShowExpenseForPdf()
        {
            string date =Session["Date"].ToString();
           

            double Total = 0;
            Expense expense = new Expense();
            expense.CreatedDate =date;
            expense.UserId =Convert.ToInt32(Session["LoginId"]);
            ViewBag.Count = 1;
            List<Expense> expenses = expenseManager.ExpenseList(expense);
            foreach (var aExpense in expenses)
            {
                Total = Total + Convert.ToDouble(aExpense.Amount);
            }
            ViewBag.Total = Total;

            return View(expenses);
        }

        public ActionResult ExpensePdf()
        {
            return new ActionAsPdf("ShowExpenseForPdf")
            {
                FileName = Server.MapPath("~/Content/CostList.pdf")
            };
        }
    }
}