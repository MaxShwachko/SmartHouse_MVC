using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartHouse_MVC.Models.Classes
{
    public class Alarm : Device
    {
        public Alarm() : base() { }
        public Alarm(string name) : base(name) { }

        [Required]
        public virtual Room Room { get; set; }
    }
}