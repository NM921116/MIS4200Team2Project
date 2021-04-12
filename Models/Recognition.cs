using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MIS4200Team2Project.Models
{
    public class Recognition
    {
        public Guid recognitionId { get; set; }




        public ICollection<Recognition> giveRecognition { get; set; }
    }
}