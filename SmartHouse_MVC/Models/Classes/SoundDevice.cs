using SmartHouse_MVC.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHouse_MVC.Models.Classes
{
    public abstract class SoundDevice : Device, ISoundRegulator
    {
        protected const int minVolume = 0;
        protected const int maxVolume = 100;
        public int CurrentVolume { get; set; }

        public SoundDevice() : this(null, 0) { }
        public SoundDevice(string name) : this(name, 0) { }
        public SoundDevice(string name, int volume) : base(name)
        {
            if (volume >= minVolume && volume <= maxVolume)
            {
                this.CurrentVolume = volume;
            }
            else
            { }
        }

        public bool IncreeseVolume()
        {
            if (this.IsStateOn() && this.IsAccess())
            {
                if (this.CurrentVolume < maxVolume)
                {
                    this.CurrentVolume++;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool DecreeseVolume()
        {
            if (this.IsStateOn() && this.IsAccess())
            {
                if (this.CurrentVolume > minVolume)
                {
                    this.CurrentVolume--;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}