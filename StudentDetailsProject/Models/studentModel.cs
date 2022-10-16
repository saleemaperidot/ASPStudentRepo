using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace StudentDetailsProject.Models
{
    public class studentModel
    {
        [Key]
        public int StudentId { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
       
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string StudentUserName { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [MembershipPassword(
    MinRequiredNonAlphanumericCharacters = 1,
    MinNonAlphanumericCharactersError = "Your password needs to contain at least one symbol (!, @, #, etc).",
    ErrorMessage = "Your password must be 6 characters long and contain at least one symbol (!, @, #, etc)."
)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string StudentPassword { get; set; }
        [Required]
        public string FathersName { get; set; }
        [Required]
        public string StudentAddress { get; set; }
        [Required]
        public string City { get; set; }
        [Required(ErrorMessage = "You must provide a phone number")]
        [Display(Name = "Home Phone")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string ContactNumber { get; set; }
        [Required(ErrorMessage = "date format 1111-11-11")]
        public DateTime DateOfbirth { get; set; }
        [Required(ErrorMessage = "date format 1111-11-11")]
        public DateTime DateOfJoining { get; set; }







    }
}