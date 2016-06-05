using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartHouse_MVC.Models.Classes
{
    public class Radiator : TemperatureDevice
    {
        public Radiator() : base() { }
        public Radiator(string name) : base(name) { }
        public Radiator(string name, int temperature) : base(name, temperature) { }
        public Radiator(string name, int temperature, int minimal, int maximal) : base(name, temperature, minimal, maximal) { }

        [Required]
        public virtual Room Room { get; set; }
    }
}