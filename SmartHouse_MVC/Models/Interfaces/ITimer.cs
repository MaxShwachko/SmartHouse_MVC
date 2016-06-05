using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse_MVC.Models.Interfaces
{
    interface ITimer
    {
        DateTime Time { get; }

        void SetTime(DateTime time);
    }
}
