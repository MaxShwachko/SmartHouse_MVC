using SmartHouse_MVC.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartHouse_MVC.Models.Classes
{
    public class Lamp : LightDevice
    {
        [Required]
        public string LampType { get; set; }
        
        public Lamp() : this(null, 0, LampTypes.Chandelier.ToString()) { }
        public Lamp(string name) : this(name, minBrightness, LampTypes.Chandelier.ToString()) { }
        public Lamp(string name, int brightness) : this(name, brightness, LampTypes.Chandelier.ToString()) { }
        public Lamp(string name, string type) : this(name, minBrightness, type) { }
        public Lamp(string name, int brightness, string type) : base(name, brightness)
        {
            this.LampType = type;
        }

        [Required]
        public virtual Room Room { get; set; }
    }
}