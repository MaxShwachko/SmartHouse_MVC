using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse_MVC.Models.Interfaces
{
    interface IChannels
    {
        int CurrentChannel { get; set; }

        bool NextChannel();
        bool PrevChannel();
        bool SetChannel(int identificator);
        bool FindChannel(string identificator);
        string GetCurrentChannelName();
    }
}
