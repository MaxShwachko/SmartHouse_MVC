using SmartHouse_MVC.Models.Classes;
using SmartHouse_MVC.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace SmartHouse_MVC.Controllers
{
    public class SmartHouseController : Controller
    {
        public ActionResult RoomsList()
        {
            if (Session["CurrentRoom"] != null)
            {
                Session["CurrentRoom"] = null;
            }
            else
            { }

            List<Room> RoomList;
            using (SmartHouseContext context = new SmartHouseContext())
            {
                RoomList = context.Rooms.ToList();
            }
            return View(RoomList);
        }

        [HttpGet]
        public ActionResult CreateRoom()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateRoom(string Name)
        {
            using (SmartHouseContext context = new SmartHouseContext())
            {
                Room newRoom = new Room(Name);
                context.Rooms.Add(newRoom);
                context.SaveChanges();
            }
            return RedirectToAction("RoomsList");
        }

        [HttpGet]
        public ActionResult EditRoom(int id)
        {
            Room room;
            using (SmartHouseContext context = new SmartHouseContext())
            {
                room = context.Rooms.FirstOrDefault(r => r.Id == id);
            }
            return View(room);
        }
        [HttpPost]
        public ActionResult EditRoom(string Name, int Id)
        {
            using (SmartHouseContext context = new SmartHouseContext())
            {
                context.Rooms.FirstOrDefault(r => r.Id == Id).Name = Name;
                context.SaveChanges();
            }
            return RedirectToAction("RoomsList");
        }

        [HttpGet]
        public ActionResult DeleteRoom(int id)
        {
            Room currentRoom = null;
            using (SmartHouseContext context = new SmartHouseContext())
            {
                currentRoom = context.Rooms.FirstOrDefault(r => r.Id == id);
            }
            return View(currentRoom);
        }
        [HttpPost]
        public ActionResult DeleteRoom(int id, string name)
        {
            using (SmartHouseContext context = new SmartHouseContext())
            {
                context.Rooms.Remove(context.Rooms.FirstOrDefault(r => r.Id == id));
                context.SaveChanges();
            }
            return RedirectToAction("RoomsList");
        }


        public ActionResult RoomInfo(int Id)
        {
            Room room;
            SmartHouseContext context = new SmartHouseContext();

            room = context.Rooms.FirstOrDefault(r => r.Id == Id);
            IDictionary<int, Device> DeviceList = GetDeviceList(room);
            Session["CurrentRoom"] = Id;
            ViewBag.CurrentRoom = Id;
            ViewBag.Counter = 0;
            return View(DeviceList);
        }

        [HttpGet]
        public ActionResult AddDevice()
        {
            CreateSelectItemList();
            return View();
        }
        [HttpPost]
        public ActionResult AddDevice(string deviceType, string lampType, string Name)
        {
            CreateNewDevice(deviceType, lampType, Name);
            return RedirectToAction("RoomInfo", new { Id = Session["CurrentRoom"] });
        }

        [HttpGet]
        public ActionResult EditDevice(int id, string type)
        {
            return View(FindDevice(id, type));
        }
        [HttpPost]
        public ActionResult EditDevice(int id, string type, string name)
        {
            RenameDevice(id, type, name);
            return RedirectToAction("RoomInfo", new { Id = Session["CurrentRoom"] });
        }

        [HttpGet]
        public ActionResult DeleteDevice(int id, string type)
        {

            return View(FindDevice(id, type));
        }
        [HttpPost]
        public ActionResult DeleteDevice(int id, string type, string name)
        {
            RemoveDevice(id, type);
            return RedirectToAction("RoomInfo", new { Id = Session["CurrentRoom"] });
        }


        private IDictionary<int, Device> GetDeviceList(Room room)
        {
            IDictionary<int, Device> deviceList = new SortedDictionary<int, Device>();
            int i = 0;
            foreach (Alarm item in room.Alarm)
            {
                deviceList.Add(i, item);
                i++;
            }
            foreach (var item in room.Conditioner)
            {
                deviceList.Add(i, item);
                i++;
            }
            foreach (var item in room.Exhauster)
            {
                deviceList.Add(i, item);
                i++;
            }
            foreach (var item in room.Fridge)
            {
                deviceList.Add(i, item);
                i++;
            }
            foreach (var item in room.Jalousie)
            {
                deviceList.Add(i, item);
                i++;
            }
            foreach (var item in room.Lamp)
            {
                deviceList.Add(i, item);
                i++;
            }
            foreach (var item in room.Radiator)
            {
                deviceList.Add(i, item);
                i++;
            }
            foreach (var item in room.Router)
            {
                deviceList.Add(i, item);
                i++;
            }
            foreach (var item in room.StereoSystem)
            {
                deviceList.Add(i, item);
                i++;
            }
            foreach (var item in room.TV)
            {
                deviceList.Add(i, item);
                i++;
            }
            return deviceList;
        }
        private void CreateSelectItemList()
        {
            SelectListItem[] deviceList = new SelectListItem[10];
            deviceList[0] = new SelectListItem { Text = "Сигнализация", Value = "Alarm", Selected = true };
            deviceList[1] = new SelectListItem { Text = "Кондиционер", Value = "Conditioner" };
            deviceList[2] = new SelectListItem { Text = "Вытяжка", Value = "Exhauster" };
            deviceList[3] = new SelectListItem { Text = "Холодильник", Value = "Fridge" };
            deviceList[4] = new SelectListItem { Text = "Жалюзи", Value = "Jalousie" };
            deviceList[5] = new SelectListItem { Text = "Лампа", Value = "Lamp" };
            deviceList[6] = new SelectListItem { Text = "Батарея", Value = "Radiator" };
            deviceList[7] = new SelectListItem { Text = "Роутер", Value = "Router" };
            deviceList[8] = new SelectListItem { Text = "Стерео система", Value = "StereoSystem" };
            deviceList[9] = new SelectListItem { Text = "Телевизор", Value = "TV" };
            ViewBag.DevicesList = deviceList;

            SelectListItem[] lampTypesList = new SelectListItem[4];
            lampTypesList[0] = new SelectListItem { Text = "Настольная", Value = LampTypes.Table.ToString() };
            lampTypesList[1] = new SelectListItem { Text = "Настенная", Value = LampTypes.Wall.ToString() };
            lampTypesList[2] = new SelectListItem { Text = "Напольная", Value = LampTypes.Floor.ToString() };
            lampTypesList[3] = new SelectListItem { Text = "Люстра", Value = LampTypes.Chandelier.ToString() };
            ViewBag.LampTypesList = lampTypesList;
        }
        private Device FindDevice(int id, string type)
        {
            Device device = null;
            using (SmartHouseContext context = new SmartHouseContext())
            {
                if (context.Alarms.Any())
                {
                    if (type == context.Alarms.FirstOrDefault().GetType().ToString())
                    {
                        return device = context.Alarms.FirstOrDefault(d => d.Id == id);
                    }
                    else { }
                }
                else { }
                if (context.Conditioners.Any())
                {
                    if (type == context.Conditioners.FirstOrDefault().GetType().ToString())
                    {
                        return device = context.Conditioners.FirstOrDefault(d => d.Id == id);
                    }
                    else { }
                }
                else { }
                if (context.Exhausters.Any())
                {
                    if (type == context.Exhausters.FirstOrDefault().GetType().ToString())
                    {
                        return device = context.Exhausters.FirstOrDefault(d => d.Id == id);
                    }
                    else { }
                }
                else { }
                if (context.Fridges.Any())
                {
                    if (type == context.Fridges.FirstOrDefault().GetType().ToString())
                    {
                        return device = context.Fridges.FirstOrDefault(d => d.Id == id);
                    }
                    else { }
                }
                else { }
                if (context.Jalousies.Any())
                {
                    if (type == context.Jalousies.FirstOrDefault().GetType().ToString())
                    {
                        return device = context.Jalousies.FirstOrDefault(d => d.Id == id);
                    }
                    else { }
                }
                else { }
                if (context.Lamps.Any())
                {
                    if (type == context.Lamps.FirstOrDefault().GetType().ToString())
                    {
                        return device = context.Lamps.FirstOrDefault(d => d.Id == id);
                    }
                    else { }
                }
                else { }
                if (context.Radiators.Any())
                {
                    if (type == context.Radiators.FirstOrDefault().GetType().ToString())
                    {
                        return device = context.Radiators.FirstOrDefault(d => d.Id == id);
                    }
                    else { }
                }
                else { }
                if (context.Routers.Any())
                {
                    if (type == context.Routers.FirstOrDefault().GetType().ToString())
                    {
                        return device = context.Routers.FirstOrDefault(d => d.Id == id);
                    }
                    else { }
                }
                else { }
                if (context.StereoSystems.Any())
                {
                    if (type == context.StereoSystems.FirstOrDefault().GetType().ToString())
                    {
                        return device = context.StereoSystems.FirstOrDefault(d => d.Id == id);
                    }
                    else { }
                }
                else { }
                if (context.TVs.Any())
                {
                    if (type == context.TVs.FirstOrDefault().GetType().ToString())
                    {
                        return device = context.TVs.FirstOrDefault(d => d.Id == id);
                    }
                    else { }
                }
                else { }
            }
            return device;
        }
        private void CreateNewDevice(string type, string lampType, string name)
        {
            using (SmartHouseContext context = new SmartHouseContext())
            {
                int id = (int)Session["CurrentRoom"];
                switch (type)
                {
                    case "Alarm":
                        Alarm newAlarm = new Alarm(name);
                        context.Rooms.FirstOrDefault(d => d.Id == id).Alarm.Add(newAlarm);
                        break;
                    case "Conditioner":
                        Conditioner newConditioner = new Conditioner(name);
                        context.Rooms.FirstOrDefault(d => d.Id == id).Conditioner.Add(newConditioner);
                        break;
                    case "Exhauster":
                        Exhauster newExhauster = new Exhauster(name);
                        context.Rooms.FirstOrDefault(d => d.Id == id).Exhauster.Add(newExhauster);
                        break;
                    case "Fridge":
                        Fridge newFridge = new Fridge(name);
                        context.Rooms.FirstOrDefault(d => d.Id == id).Fridge.Add(newFridge);
                        break;
                    case "Jalousie":
                        Jalousie newJalousie = new Jalousie(name);
                        context.Rooms.FirstOrDefault(d => d.Id == id).Jalousie.Add(newJalousie);
                        break;
                    case "Lamp":
                        Lamp newLamp = new Lamp(name, lampType);
                        context.Rooms.FirstOrDefault(d => d.Id == id).Lamp.Add(newLamp);
                        break;
                    case "Radiator":
                        Radiator newRadiator = new Radiator(name);
                        context.Rooms.FirstOrDefault(d => d.Id == id).Radiator.Add(newRadiator);
                        break;
                    case "Router":
                        Router newRouter = new Router(name);
                        context.Rooms.FirstOrDefault(d => d.Id == id).Router.Add(newRouter);
                        break;
                    case "StereoSystem":
                        StereoSystem newStereoSystem = new StereoSystem(name);
                        context.Rooms.FirstOrDefault(d => d.Id == id).StereoSystem.Add(newStereoSystem);
                        break;
                    case "TV":
                        TV newTV = new TV(name);
                        context.Rooms.FirstOrDefault(d => d.Id == id).TV.Add(newTV);
                        break;
                    default:
                        Alarm newAlarma = new Alarm(name);
                        context.Rooms.FirstOrDefault(d => d.Id == id).Alarm.Add(newAlarma);
                        break;
                }
                context.SaveChanges();
            }
        }
        private void RenameDevice(int id, string type, string name)
        {
            using (SmartHouseContext context = new SmartHouseContext())
            {
                if (context.Alarms.Any())
                {
                    if (type == context.Alarms.FirstOrDefault().GetType().ToString())
                    {
                        Alarm device = context.Alarms.Find(id);
                        device.Name = name;
                        device.Room = context.Rooms.Find(Session["CurrentRoom"]);
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
                        device.Name = name;
                        device.Room = context.Rooms.Find(Session["CurrentRoom"]);
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
                        device.Name = name;
                        device.Room = context.Rooms.Find(Session["CurrentRoom"]);
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
                        device.Name = name;
                        device.Room = context.Rooms.Find(Session["CurrentRoom"]);
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
                        device.Name = name;
                        device.Room = context.Rooms.Find(Session["CurrentRoom"]);
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
                        device.Name = name;
                        device.Room = context.Rooms.Find(Session["CurrentRoom"]);
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
                        device.Name = name;
                        device.Room = context.Rooms.Find(Session["CurrentRoom"]);
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
                        device.Name = name;
                        device.Room = context.Rooms.Find(Session["CurrentRoom"]);
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
                        device.Name = name;
                        device.Room = context.Rooms.Find(Session["CurrentRoom"]);
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
                        device.Name = name;
                        device.Room = context.Rooms.Find(Session["CurrentRoom"]);
                        context.SaveChanges();
                        return;
                    }
                    else { }
                }
                else { }
            }
            return;
        }
        private void RemoveDevice(int id, string type)
        {
            using (SmartHouseContext context = new SmartHouseContext())
            {
                if (context.Alarms.Any())
                {
                    if (type == context.Alarms.FirstOrDefault().GetType().ToString())
                    {
                        context.Alarms.Remove(context.Alarms.FirstOrDefault(d => d.Id == id));
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
                        context.Conditioners.Remove(context.Conditioners.FirstOrDefault(d => d.Id == id));
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
                        context.Exhausters.Remove(context.Exhausters.FirstOrDefault(d => d.Id == id));
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
                        context.Fridges.Remove(context.Fridges.FirstOrDefault(d => d.Id == id));
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
                        context.Jalousies.Remove(context.Jalousies.FirstOrDefault(d => d.Id == id));
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
                        context.Lamps.Remove(context.Lamps.FirstOrDefault(d => d.Id == id));
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
                        context.Radiators.Remove(context.Radiators.FirstOrDefault(d => d.Id == id));
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
                        context.Routers.Remove(context.Routers.FirstOrDefault(d => d.Id == id));
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
                        context.StereoSystems.Remove(context.StereoSystems.FirstOrDefault(d => d.Id == id));
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
                        context.TVs.Remove(context.TVs.FirstOrDefault(d => d.Id == id));
                        context.SaveChanges();
                        return;
                    }
                    else { }
                }
                else { }
            }
            return;
        }

    }
}