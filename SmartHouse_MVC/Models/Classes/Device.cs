using SmartHouse_MVC.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartHouse_MVC.Models.Classes
{
    public abstract class Device : IAccessable, IStatable
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public bool Access { get; set; }
        public bool State { get; set; }

        public Device() : this (null) { }
        public Device(string name)
        {
            if (name == null)
            {
                this.Name = DateTime.Now.ToString();
            }
            else
            {
                this.Name = name;
            }
            this.State = false;
            this.Access = true;
        }

        public void OnOff()
        {
            this.State = !this.State;
        }
        public bool IsStateOn()
        {
            if (this.State)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsAccess()
        {
            if (this.Access)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}