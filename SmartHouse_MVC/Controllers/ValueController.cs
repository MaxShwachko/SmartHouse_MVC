using SmartHouse_MVC.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartHouse_MVC.Controllers
{
    public class ValueController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage Post([FromBody] string value)
        {
            string[] data = value.Split(' ');

            OnOffDevice(int.Parse(data[0]), data[1], int.Parse(data[2]));

            return new HttpResponseMessage(HttpStatusCode.Created);
        }

        [HttpGet]
        public string Get(string value)
        {
            string[] data = value.Split(' ');
            if (data[1] == "plus")
            {
                return "" + RegulateDevice(data[0], true, int.Parse(data[2]), data[3], int.Parse(data[4]));
            }
            else
            {
                return "" + RegulateDevice(data[0], false, int.Parse(data[2]), data[3], int.Parse(data[4]));
            }
        }

        private void OnOffDevice(int id, string type, int roomId)
        {
            using (SmartHouseContext context = new SmartHouseContext())
            {
                if (context.Alarms.Any())
                {
                    if (type == context.Alarms.FirstOrDefault().GetType().ToString())
                    {
                        Alarm device = context.Alarms.Find(id);
                        device.OnOff();
                        device.Room = context.Rooms.Find(roomId);
                        context.SaveChanges();
                        return;
                    }
                    else { }
                }
                else { }
                if (context.Conditioners.Any())
                {
                    if (type == context.Conditioners.FirstOrDefault().GetType().ToString())
                    {
                        Conditioner device = context.Conditioners.Find(id);
                        device.OnOff();
                        device.Room = context.Rooms.Find(roomId);
                        context.SaveChanges();
                        return;
                    }
                    else { }
                }
                else { }
                if (context.Exhausters.Any())
                {
                    if (type == context.Exhausters.FirstOrDefault().GetType().ToString())
                    {
                        Exhauster device = context.Exhausters.Find(id);
                        device.OnOff();
                        device.Room = context.Rooms.Find(roomId);
                        context.SaveChanges();
                        return;
                    }
                    else { }
                }
                else { }
                if (context.Fridges.Any())
                {
                    if (type == context.Fridges.FirstOrDefault().GetType().ToString())
                    {
                        Fridge device = context.Fridges.Find(id);
                        device.OnOff();
                        device.Room = context.Rooms.Find(roomId);
                        context.SaveChanges();
                        return;
                    }
                    else { }
                }
                else { }
                if (context.Jalousies.Any())
                {
                    if (type == context.Jalousies.FirstOrDefault().GetType().ToString())
                    {
                        Jalousie device = context.Jalousies.Find(id);
                        device.OnOff();
                        device.Room = context.Rooms.Find(roomId);
                        context.SaveChanges();
                        return;
                    }
                    else { }
                }
                else { }
                if (context.Lamps.Any())
                {
                    if (type == context.Lamps.FirstOrDefault().GetType().ToString())
                    {
                        Lamp device = context.Lamps.Find(id);
                        device.OnOff();
                        device.Room = context.Rooms.Find(roomId);
                        context.SaveChanges();
                        return;
                    }
                    else { }
                }
                else { }
                if (context.Radiators.Any())
                {
                    if (type == context.Radiators.FirstOrDefault().GetType().ToString())
                    {
                        Radiator device = context.Radiators.Find(id);
                        device.OnOff();
                        device.Room = context.Rooms.Find(roomId);
                        context.SaveChanges();
                        return;
                    }
                    else { }
                }
                else { }
                if (context.Routers.Any())
                {
                    if (type == context.Routers.FirstOrDefault().GetType().ToString())
                    {
                        Router device = context.Routers.Find(id);
                        device.OnOff();
                        device.Room = context.Rooms.Find(roomId);
                        context.SaveChanges();
                        return;
                    }
                    else { }
                }
                else { }
                if (context.StereoSystems.Any())
                {
                    if (type == context.StereoSystems.FirstOrDefault().GetType().ToString())
                    {
                        StereoSystem device = context.StereoSystems.Find(id);
                        device.OnOff();
                        device.Room = context.Rooms.Find(roomId);
                        context.SaveChanges();
                        return;
                    }
                    else { }
                }
                else { }
                if (context.TVs.Any())
                {
                    if (type == context.TVs.FirstOrDefault().GetType().ToString())
                    {
                        TV device = context.TVs.Find(id);
                        device.OnOff();
                        device.Room = context.Rooms.Find(roomId);
                        context.SaveChanges();
                        return;
                    }
                    else { }
                }
                else { }
            }
            return;
        }
        private string RegulateDevice(string onChange, bool sign, int id, string type, int roomId)
        {
            using (SmartHouseContext context = new SmartHouseContext())
            {
                if (context.Conditioners.Any())
                {
                    if (type == context.Conditioners.FirstOrDefault().GetType().ToString())
                    {
                        Conditioner device = context.Conditioners.Find(id);
                        if (sign)
                        {
                            device.IncreeseTemperature();
                        }
                        else
                        {
                            device.DecreeseTemperature();
                        }
                        device.Room = context.Rooms.Find(roomId);
                        context.SaveChanges();
                        return device.CurrentTemperature.ToString();
                    }
                    else { }
                }
                else { }
                if (context.Exhausters.Any())
                {
                    if (type == context.Exhausters.FirstOrDefault().GetType().ToString())
                    {
                        Exhauster device = context.Exhausters.Find(id);
                        if (sign)
                        {
                            device.IncreesePower();
                        }
                        else
                        {
                            device.DecreesePower();
                        }
                        device.Room = context.Rooms.Find(roomId);
                        context.SaveChanges();
                        return device.CurrentPower.ToString();
                    }
                    else { }
                }
                else { }
                if (context.Fridges.Any())
                {
                    if (type == context.Fridges.FirstOrDefault().GetType().ToString())
                    {
                        Fridge device = context.Fridges.Find(id);
                        if (sign)
                        {
                            device.IncreeseTemperature();
                        }
                        else
                        {
                            device.DecreeseTemperature();
                        }
                        device.Room = context.Rooms.Find(roomId);
                        context.SaveChanges();
                        return device.CurrentTemperature.ToString();
                    }
                    else { }
                }
                else { }
                if (context.Lamps.Any())
                {
                    if (type == context.Lamps.FirstOrDefault().GetType().ToString())
                    {
                        Lamp device = context.Lamps.Find(id);
                        if (sign)
                        {
                            device.IncreeseBrightness();
                        }
                        else
                        {
                            device.DecreeseBrightness();
                        }
                        device.Room = context.Rooms.Find(roomId);
                        context.SaveChanges();
                        return device.CurrentBrightness.ToString();
                    }
                    else { }
                }
                else { }
                if (context.Radiators.Any())
                {
                    if (type == context.Radiators.FirstOrDefault().GetType().ToString())
                    {
                        Radiator device = context.Radiators.Find(id);
                        if (sign)
                        {
                            device.IncreeseTemperature();
                        }
                        else
                        {
                            device.DecreeseTemperature();
                        }
                        device.Room = context.Rooms.Find(roomId);
                        context.SaveChanges();
                        return device.CurrentTemperature.ToString();
                    }
                    else { }
                }
                if (context.StereoSystems.Any())
                {
                    if (type == context.StereoSystems.FirstOrDefault().GetType().ToString())
                    {
                        StereoSystem device = context.StereoSystems.Find(id);
                        if (sign)
                        {
                            device.IncreeseVolume();
                        }
                        else
                        {
                            device.DecreeseVolume();
                        }
                        device.Room = context.Rooms.Find(roomId);
                        context.SaveChanges();
                        return device.CurrentVolume.ToString();
                    }
                    else { }
                }
                else { }
                if (context.TVs.Any())
                {
                    if (type == context.TVs.FirstOrDefault().GetType().ToString())
                    {
                        TV device = context.TVs.Find(id);
                        if (onChange == "volume")
                        {
                            if (sign)
                            {
                                device.IncreeseVolume();
                            }
                            else
                            {
                                device.DecreeseVolume();
                            }
                        }
                        else
                        if (onChange == "channel")
                        {
                            if (sign)
                            {
                                device.NextChannel();
                            }
                            else
                            {
                                device.PrevChannel();
                            }
                        }
                        else
                        {
                            if (sign)
                            {
                                device.IncreeseBrightness();
                            }
                            else
                            {
                                device.DecreeseBrightness();
                            }
                        }
                        device.Room = context.Rooms.Find(roomId);
                        context.SaveChanges();
                        if (onChange == "volume")
                        {
                            return device.CurrentVolume.ToString();
                        }
                        else
                        if (onChange == "channel")
                        {
                            return device.GetCurrentChannelName();
                        }
                        else
                        {
                            return device.CurrentBrightness.ToString();
                        }
                    }
                    else { }
                }
                else { }
            }
            return null;
        }


    }
}
