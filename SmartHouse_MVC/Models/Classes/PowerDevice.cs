using SmartHouse_MVC.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHouse_MVC.Models.Classes
{
    public abstract class PowerDevice : Device, IPowerRegulator
    {
        protected const int minPower = 0;
        protected const int maxPower = 100;
        public int CurrentPower { get; set; }

        public PowerDevice() : this(null, minPower) { }
        public PowerDevice(string name) : this(name, minPower) { }
        public PowerDevice(string name, int power)
            : base(name)
        {
            if (power <= maxPower && power >= minPower)
            {
                this.CurrentPower = power;
            }
            else
            { }
        }

        public bool IncreesePower()
        {
            if (this.IsStateOn() && this.IsAccess())
            {
                if (this.CurrentPower < maxPower)
                {
                    this.CurrentPower++;
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
        public bool DecreesePower()
        {
            if (this.IsStateOn() && this.IsAccess())
            {
                if (this.CurrentPower > minPower)
                {
                    this.CurrentPower--;
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