using MIS4200Team2Project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
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
      public DbSet<Reccomendation> Recomendation { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();  // note: this is all one line!
        }


    }
}