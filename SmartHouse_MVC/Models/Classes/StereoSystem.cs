using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartHouse_MVC.Models.Classes
{
    public class StereoSystem : SoundDevice
    {
        public StereoSystem() : base() { }
        public StereoSystem(string name) : base(name) { }
        public StereoSystem(string name, int volume) : base(name, volume) { }

        [Required]
        public virtual Room Room { get; set; }
    }
}