namespace SmartHouse_MVC.Models.Classes
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Validation;
    using System.Linq;
    using System.Text;
    public class SmartHouseContext : DbContext
    {
        public SmartHouseContext()
            : base("name=SmartHouseContext")
        {
        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Alarm> Alarms { get; set; }
        public DbSet<Conditioner> Conditioners { get; set; }
        public DbSet<Exhauster> Exhausters { get; set; }
        public DbSet<Fridge> Fridges { get; set; }
        public DbSet<Jalousie> Jalousies { get; set; }
        public DbSet<Lamp> Lamps { get; set; }
        public DbSet<Radiator> Radiators { get; set; }
        public DbSet<Router> Routers { get; set; }
        public DbSet<StereoSystem> StereoSystems { get; set; }
        public DbSet<TV> TVs { get; set; }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var sb = new StringBuilder(); //

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                    ); // Add the original exception as the innerException
            }
        }
    }

}