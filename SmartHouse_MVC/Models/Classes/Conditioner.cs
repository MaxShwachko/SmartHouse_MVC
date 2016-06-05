using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartHouse_MVC.Models.Classes
{
    public class Conditioner : TemperatureDevice
    {
        public Conditioner() : base() { }
        public Conditioner(string name) : base(name) { }
        public Conditioner(string name, int temperature) : base(name, temperature) { }
        public Conditioner(string name, int temperature, int minimal, int maximal) : base(name, temperature, minimal, maximal) { }

        [Required]
        public virtual Room Room { get; set; }
    }
}