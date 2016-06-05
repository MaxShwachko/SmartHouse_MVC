using SmartHouse_MVC.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHouse_MVC.Models.Classes
{
    public abstract class TemperatureDevice : Device, ITemperatureRegulator
    {
        public int CurrentTemperature { get; set; }
        public int MinimalTemperature { get; set; }
        public int MaximalTemperature { get; set; }

        public TemperatureDevice() : this(null, 0, -20, 10) { }
        public TemperatureDevice(string name) : this(name, 0, -20, 10) { }
        public TemperatureDevice(string name, int temperature) : this(name, temperature, -20, 10) { }
        public TemperatureDevice(string name, int temperature, int minimal, int maximal)
            : base(name)
        {
            this.MinimalTemperature = minimal;
            this.MaximalTemperature = maximal;
            this.OnOff();
            this.SetTemperature(temperature);
            this.OnOff();
        }

        public bool IncreeseTemperature()
        {
            if (this.IsStateOn() && this.IsAccess())
            {
                if (this.CurrentTemperature < this.MaximalTemperature)
                {
                    this.CurrentTemperature++;
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
        public bool DecreeseTemperature()
        {
            if (this.IsStateOn() && this.IsAccess())
            {
                if (this.CurrentTemperature > this.MinimalTemperature)
                {
                    this.CurrentTemperature--;
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
        public bool SetTemperature(int temperature)
        {
            if (this.IsStateOn() && this.IsAccess())
            {
                if (temperature >= this.MinimalTemperature && temperature <= this.MaximalTemperature)
                {
                    this.CurrentTemperature = temperature;
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