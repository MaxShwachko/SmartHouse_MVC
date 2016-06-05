using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartHouse_MVC.Models.Classes
{
    public class Fridge : TemperatureDevice
    {
        public Fridge() : base() { }
        public Fridge(string name) : base(name) { }
        public Fridge(string name, int temperature) : base(name, temperature) { }
        public Fridge(string name, int temperature, int minimal, int maximal) : base(name, temperature, minimal, maximal) { }

        [Required]
        public virtual Room Room { get; set; }
    }
}