using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartHouse_MVC.Models.Classes
{
    public class Jalousie : Device
    {
        public Jalousie() : base() { }
        public Jalousie(string name) : base(name) { }

        [Required]
        public virtual Room Room { get; set; }
    }
}