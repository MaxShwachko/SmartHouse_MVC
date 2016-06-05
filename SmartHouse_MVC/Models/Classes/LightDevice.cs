using SmartHouse_MVC.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHouse_MVC.Models.Classes
{
    public abstract class LightDevice : Device, ILightRegulator
    {
        protected const int minBrightness = 0;
        protected const int maxBrightness = 100;
        public int CurrentBrightness { get; set; }

        public LightDevice() : this(null, 0) { }
        public LightDevice(string name) : this(name, 0) { }
        public LightDevice(string name, int brightness)
            : base(name)
        {
            if (brightness >= minBrightness && brightness <= maxBrightness)
            {
                this.CurrentBrightness = brightness;
            }
            else
            { }
        }

        public bool IncreeseBrightness()
        {
            if (this.IsStateOn() && this.IsAccess())
            {
                if (this.CurrentBrightness < maxBrightness)
                {
                    this.CurrentBrightness++;
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
        public bool DecreeseBrightness()
        {
            if (this.IsStateOn() && this.IsAccess())
            {
                if (this.CurrentBrightness > minBrightness)
                {
                    this.CurrentBrightness--;
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