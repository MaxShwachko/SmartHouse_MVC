using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartHouse_MVC.Models.Classes
{
    public class Room
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public Room() : this(null) { }
        public Room(string name)
        {
            if (name == null)
            {
                this.Name = DateTime.Now.ToString();
            }
            else
            {
                this.Name = name;
            }
        }

        public virtual ICollection<Alarm> Alarm { get; set; }
        public virtual ICollection<Conditioner> Conditioner { get; set; }
        public virtual ICollection<Exhauster> Exhauster { get; set; }
        public virtual ICollection<Fridge> Fridge { get; set; }
        public virtual ICollection<Jalousie> Jalousie { get; set; }
        public virtual ICollection<Lamp> Lamp { get; set; }
        public virtual ICollection<Radiator> Radiator { get; set; }
        public virtual ICollection<Router> Router { get; set; }
        public virtual ICollection<StereoSystem> StereoSystem { get; set; }
        public virtual ICollection<TV> TV { get; set; }
    }
}