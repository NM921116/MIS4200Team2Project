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


        public Guid ReccomendationId { get; set; }

        [Display(Name = "Employee Getting Recognition")]
        [Required(ErrorMessage = "Please Select an Employee")]

        public Guid employeeId { get; set; }

        [ForeignKey("employeeId")]

        public virtual Profile Employee { get; set; }

        [Display(Name = "Employee Giving Recognition")]  
        public Guid recognizerId {get; set;}
        [ForeignKey("recognizerId")]
        
        public virtual Profile Recognizer { get; set; }

      [Display(Name = "Recognition Awarded")]
      public Guid recognitionId { get; set; }
      [ForeignKey("recognitionId")]

      //public virtual Profile Recognition {​ get; set; }​
      public virtual Profile Recognition { get; set; }




        [Display (Name ="Date Awarded")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode =true)]
        public Nullable<System.DateTime> awardDate { get; set; }

        [Display(Name = "Why is this person getting this award!")]


     [Required(ErrorMessage = "Please enter why this person is getting this award.")]

     public string description { get; set; }


    }
}