using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse_MVC.Models.Interfaces
{
    interface ITemperatureRegulator : ITemperature
    {
        bool IncreeseTemperature();
        bool DecreeseTemperature();
        bool SetTemperature(int identificator);
    }
}
