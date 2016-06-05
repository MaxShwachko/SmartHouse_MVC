using SmartHouse_MVC.Models.Enums;
using SmartHouse_MVC.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartHouse_MVC.Models.Classes
{
    public class TV : Device, ISoundRegulator, ILightRegulator, IChannels
    {
        protected const int minVolume = 0;
        protected const int maxVolume = 100;
        protected const int minBrightness = 0;
        protected const int maxBrightness = 100;

        public int CurrentVolume { get; set; }
        public int CurrentBrightness { get; set; }
        public int CurrentChannel { get; set; }
        
        public TV() : this(null) { }
        public TV(string name)
            : base(name)
        {
  //          this.Channels = new List<string>();
  ///          this.Channels.Add("1+1");
    //        this.Channels.Add("Discovery");
      //      this.Channels.Add("National Geographic");
        //    this.Channels.Add("HBO");
            this.CurrentChannel = (int)ChannelList.Discovery;
            this.CurrentVolume = minVolume;
            this.CurrentBrightness = minBrightness;
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
        public bool NextChannel()
        {
            if (this.IsStateOn() && this.IsAccess())
            {
                if (this.CurrentChannel < sizeof(ChannelList) - 1)
                {
                    this.CurrentChannel++;
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
        public bool PrevChannel()
        {
            if (this.IsStateOn() && this.IsAccess())
            {
                if (this.CurrentChannel > 0)
                {
                    this.CurrentChannel--;
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
        public bool SetChannel(int channel)
        {
            if (this.IsStateOn() && this.IsAccess())
            {
                if (channel >= 0 && channel < sizeof(ChannelList))
                {
                    this.CurrentChannel = channel;
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
        public bool FindChannel(string channel)
        {
            if (this.IsStateOn() && this.IsAccess())
            {
                if (channel != null)
                {
                    foreach (ChannelList ch in Enum.GetValues(typeof(ChannelList)))
                    {
                        if (ch.ToString() == channel)
                        {
                            this.CurrentChannel = (int)ch;
                            return true;
                        }
                        else
                        { }
                    }
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
            return false;
        }
        public string GetCurrentChannelName()
        {
            return Enum.GetName(typeof(ChannelList), this.CurrentChannel);
        }

        [Required]
        public virtual Room Room { get; set; }
    }
}