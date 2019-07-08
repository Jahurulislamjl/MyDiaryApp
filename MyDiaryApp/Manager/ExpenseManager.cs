using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyDiaryApp.Models;
using MyDiaryApp.GateWay;

namespace MyDiaryApp.Manager
{
    public class ExpenseManager
    {
        ExpenseGateWay expenseGateWay = new ExpenseGateWay();

        public int SaveExpense(Expense expense)
        {
            return expenseGateWay.SaveExpense(expense);

        }

        public List<Expense> ExpenseList(Expense expense)
        {
            return expenseGateWay.ExpenseList(expense);
        }

        public List<Expense> MonthExpenseList(Expense expense, int month, int year)
        {
            return expenseGateWay.MonthExpenseList(expense,month,year);
        }

        public List<Expense> YearExpenseList(Expense expense, int year)
        {
            return expenseGateWay.YearExpenseList(expense,year);
        }
    }
}