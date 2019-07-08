using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyDiaryApp.Models
{
    public class Note
    {
        [Key] 
        public int NotId { get; set; }

        public int UserId { get; set; }

        public string CreatedDateTime { get; set; }

        [Required]
        [Display(Name = " ")]
        public string NoteTitle { get; set; }
         
        [Required]
        [Display(Name = " ")]
        public string NoteDescription { get; set; }
    }
}