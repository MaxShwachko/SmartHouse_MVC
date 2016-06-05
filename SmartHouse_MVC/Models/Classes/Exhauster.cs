using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartHouse_MVC.Models.Classes
{
    public class Exhauster : PowerDevice
    {
        public Exhauster() : base() { }
        public Exhauster(string name) : base(name) { }
        public Exhauster(string name, int power) : base(name, power) { }

        [Required]
        public virtual Room Room { get; set; }
    }
}