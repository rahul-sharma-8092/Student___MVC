using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Student___MVC.Models
{
    public class Student
    {
        [Key]
        public int  StuId { get; set; }

        [Display(Name = "Name: ")]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
            ErrorMessage = "Please enter a valid E-Mail adress")]
        [Display(Name = "Email Id: ")]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Password: ")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{6,15}$",
            ErrorMessage = "Password must be between 6 and 20 characters and contain one uppercase letter, one lowercase letter, one digit and one special character.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Date of Birth: ")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Mobile No: ")]
        [DataType(DataType.PhoneNumber)]
        public string Mobile { get; set; }

        [RegularExpression(@"^([a-zA-Z0-9 \.\&\'\-]+)$", ErrorMessage = "Invalid Address")]
        [Display(Name = "Address: ")]
        [StringLength(250)]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [Display(Name = "Select Country: ")]
        public String Country { get; set; }

        [Display(Name = "Select State: ")]
        public string State { get; set; }

        [Display(Name = "Select District: ")]
        public string District { get; set; }

        [Display(Name = "Select Dp Image: ")]
        public HttpPostedFile DpImage { get; set; }
        public string DpImageName { get; set; }

        [Display(Name = "Select Certificate (.pdf): ")]
        public HttpPostedFile Certificate { get; set; }
        public string CertificateName { get; set; }
    }
}