using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartHouse_MVC.Models.Classes
{
    public class Router : Device
    {
        public Router() : base() { }
        public Router(string name) : base(name) { }

        [Required]
        public virtual Room Room { get; set; }
    }
}