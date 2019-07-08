using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyDiaryApp.Models
{
    public class Login
    {
        [Key]

        public int LoginId { get; set; }

        [Required]
        [Display(Name = " ")]
        [EmailAddress(ErrorMessage = "Invalide email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = " ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}