using MIS4200Team2Project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MIS4200Team2Project.DAL
{
    public class MIS4200Team2Context    :   DbContext
    {
        public MIS4200Team2Context()    :   base("name=DefaultConnection")
        {

        }
        public DbSet<Profile> profile { get; set; }
    }
}