using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse_MVC.Models.Interfaces
{
    interface ISoundRegulator : ISound
    {
        bool IncreeseVolume();
        bool DecreeseVolume();
    }
}
