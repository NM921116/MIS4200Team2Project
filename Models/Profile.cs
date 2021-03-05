using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MIS4200Team2Project.Models
{
    public class Profile
    {
        [Display(Name = "User ID")]
        public Guid profileID { get; set; }
       
        [Display(Name = "Last Name")]
        public string lastName { get; set; }

        [Display(Name = "First Name")]
        public string firstName { get; set; }

        [Display(Name = "Name")]
        public string fullName
        {
            get
            {
                return lastName + ", " + firstName;
            }
        }
        [Display(Name = "Employee Since")]
        public DateTime hireDate { get; set; }

        [Display(Name = "Phone Number")]
        public string phone { get; set; }

        [Display(Name = "Email")]
        public string email { get; set; }

        [Display(Name = "Position")]
        public string position { get; set; }

        [Display(Name = "Operating Group")]
        public string operatingGroup { get; set; }

        [Display(Name = "City")]
        public string city { get; set; }

        [Display(Name = "State")]
        public string state { get; set; }

        [Display(Name = "Bio")]
        public string bio { get; set; }
    }
}