using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Xml.Linq;

namespace StudentDetailsProject.Models
{
    public class Login
    {
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string usrname { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [MembershipPassword(
    MinRequiredNonAlphanumericCharacters = 1,
    MinNonAlphanumericCharactersError = "Your password needs to contain at least one symbol (!, @, #, etc).",
    ErrorMessage = "Your password must be 6 characters long and contain at least one symbol (!, @, #, etc)."
)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]

        public string password { get; set; }
    }
}