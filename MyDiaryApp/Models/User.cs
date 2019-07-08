using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyDiaryApp.Models
{
    public class User
    {
        [Key]

        public int UserId { get; set; }

        [Required]
        [Display(Name = " ")]
        //[StringLength(15,ErrorMessage = "The name contains 1 to 15 characters")]
        [RegularExpression("^([A-Z]{1}[a-zA-Z .'-]{1,15})$", ErrorMessage = "2 to 15 alphabet and first letter uppercase")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = " ")]
        [RegularExpression("^([A-Z]{1}[a-zA-Z .'-]{1,15})$", ErrorMessage = "2 to 15 alphabet and first letter uppercase")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = " ")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        [RegularExpression("^[a-z0-9._%+-]+@[a-z0-9.-]+.[a-z]{2,4}$", ErrorMessage = "2 to 15 alphabet and first letter uppercase")]
        [System.Web.Mvc.Remote("IsEmailExist", "User", HttpMethod = "POST", ErrorMessage = "Email already exist")]
        public string Email { get; set; }

        [Required]
        [Display(Name = " ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = " ")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password don't match!!")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = " ")]
        [DataType(DataType.Date)]
        public string DateOfBirth { get; set; }

        [Required]
        [Display(Name = " ")]
        public string Gender { get; set; }

        [Required]
        [Display(Name = " ")]
        [RegularExpression(@"^\(?([0-9]{11})$", ErrorMessage = "Invalid Contact no")]
        [StringLength(11, ErrorMessage = "Invalid Contact no")]
        [System.Web.Mvc.Remote("CheckPhone", "User", HttpMethod = "POST")]
        public string ContactNo { get; set; }
    }
}