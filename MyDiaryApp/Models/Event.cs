using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyDiaryApp.Models
{
    public class Event
    {
        [Key]

        public int EventId { get; set; }

        public int UserId { get; set; }


        [DataType(DataType.DateTime)]
        public string CreatedDateTime { get; set; }

        [Display(Name=" ")]
        [DataType(DataType.Date)]
        public string EventDate { get; set; }

        [DataType(DataType.Time)]
        [Display(Name ="")]
        public string EventTime { get; set; }

        [Display(Name = "")]
        [DataType(DataType.Date)]
        public string ReminderDate { get; set; }

        [Display(Name = "")]
        [DataType(DataType.Time)]
        public string ReminderTime { get; set; }

        [Display(Name = "")]
        public string EventDescription { get; set; }

        [Display(Name = "")]
        public int NotificationStatus { get; set; }
    }
}