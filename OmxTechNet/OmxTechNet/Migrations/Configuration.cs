namespace OmxTechNet.Migrations
{
    using Models.DB;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OmxTechNet.Models.DB.OmxtechDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(OmxTechNet.Models.DB.OmxtechDbContext context)
        {

            //context.tbl_accounts.AddOrUpdate(x => x.AID,
            //    new tbl_Account {Username="taymur",
            //                     Password="taymur",
            //                     FName="Taymur",
            //                     LName ="Al-Shanfari",
            //                     Role="Admin"});

            //context.SaveChanges();
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
