using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

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
        [Required]
        public string StudentUserName { get; set; }
        [Required]
        public string StudentPassword { get; set; }
        [Required]
        public string FathersName { get; set; }
        [Required]
        public string StudentAddress { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string ContactNumber { get; set; }
        [Required]
        public DateTime DateOfbirth { get; set; }
        [Required]
        public DateTime DateOfJoining { get; set; }







    }
}