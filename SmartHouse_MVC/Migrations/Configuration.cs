namespace SmartHouse_MVC.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SmartHouse_MVC.Models.Classes.SmartHouseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "SmartHouse_MVC.Models.Classes.SmartHouseContext";
        }

        protected override void Seed(SmartHouse_MVC.Models.Classes.SmartHouseContext context)
        {

        }
    }
}
