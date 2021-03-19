namespace MIS4200Team2Project.Migrations.MIS4200Team2Context
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MIS4200Team2Project.DAL.MIS4200Team2Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            MigrationsDirectory = @"Migrations\MIS4200Team2Context";
            ContextKey = "MIS4200Team2Project.DAL.MIS4200Team2Context";
        }

        protected override void Seed(MIS4200Team2Project.DAL.MIS4200Team2Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
