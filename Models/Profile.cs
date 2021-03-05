using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MIS4200Team2Project.Models
{
    public class Profile
    {
        public Guid profileID { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string fullName
        {
            get
            {
                return lastName + ", " + firstName;
            }
        }
        public DateTime hireDate { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string position { get; set; }
        public string operatingGroup { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string bio { get; set; }
    }
}