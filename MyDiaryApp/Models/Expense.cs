using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyDiaryApp.Models
{
    public class Expense
    {
        [Key]
        public int ExpenseId { get; set; }

        public int UserId { get; set; }

        public string CreatedDate { get; set; }

        [Display(Name ="")]
        public string ItemName { get; set; }

        [Display(Name = "")]
        public string Amount { get; set; } 


        public double Total { get; set; } 

    }
}