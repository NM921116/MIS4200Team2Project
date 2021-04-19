using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MIS4200Team2Project.Models
{
    public class Reccomendation
    {


        public int ReccomendationId { get; set; }






        [Display(Name = "Employee Giving Recognition")]
        public Guid recognizerId { get; set; }
        [ForeignKey("recognizerId")]

        public virtual Profile Recognizer { get; set; }

        [Display(Name = "Recognition Awarded To")]
        [Required(ErrorMessage = "Please Select an Employee")]
        public Guid recognitionId { get; set; }
        [ForeignKey("recognitionId")]

        //public virtual Profile Recognition {​ get; set; }​
        public virtual Profile Recognition { get; set; }


        // public string[] coreValues = new string[7] {"Commit to Delivery Excellence", "Embrace Integrity and Openness", "Practice Responsible Stewardship", "Invest in an Exceptional Culture", "Ignite Passion for the Greater Good", "Strive to Innovate", "Live a Balanced Life"};
        [Display(Name = "Core value recognized")]
        public coreValue award { get; set; }

        public enum coreValue
        {
            Excellence = 1,
            Integrity = 2,
            Stewardship = 3,
            Culture = 4,
            Passion = 5,
            Innovative = 6,
            Balanced = 7
        }



        [Display (Name ="Date Awarded")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode =true)]
        public Nullable<System.DateTime> awardDate { get; set; }

        [Display(Name = "Why is this person getting this award!")]


     [Required(ErrorMessage = "Please enter why this person is getting this award.")]

     public string description { get; set; }


    }
}