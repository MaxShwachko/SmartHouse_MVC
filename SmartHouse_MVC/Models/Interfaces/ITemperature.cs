using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse_MVC.Models.Interfaces
{
    interface ITemperature
    {
        int CurrentTemperature { get; set; }
        int MinimalTemperature { get; set; }
        int MaximalTemperature { get; set; }
    }
}
