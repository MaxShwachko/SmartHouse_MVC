using SmartHouse_MVC.Models.Classes;
using SmartHouse_MVC.Models.Enums;
using SmartHouse_MVC.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartHouse_MVC.Helpers
{
    public static class DeviceBuilder
    {
        public static MvcHtmlString AnyDeviceBuilder(this HtmlHelper html, Device item, int roomId)
        {
            string result = null;
            string additionalResult = null;
            TagBuilder h = new TagBuilder("h3");
            h.AddCssClass("text-center");
            h.SetInnerText(item.Name);
            result += h.ToString();
            TagBuilder input = new TagBuilder("input");
            input.Attributes.Add("type", "checkbox");
            input.Attributes.Add("id", item.Id.ToString() + " " + item.GetType().ToString() + " " + roomId);
            string id = null;
            input.Attributes.TryGetValue("id", out id);
            input.Attributes.Add("data-id", id);
            TagBuilder img = new TagBuilder("img");

            if (item is Alarm)
            {
                img.Attributes.Add("data-action", "Alarm");
                img.Attributes.Add("data-on", "/Content/Images/Alarm_on.jpg");
                img.Attributes.Add("data-off", "/Content/Images/Alarm.jpg");
                if (item.State)
                {
                    img.Attributes.Add("src", "/Content/Images/Alarm_on.jpg");
                }
                else
                {
                    img.Attributes.Add("src", "/Content/Images/Alarm.jpg");
                }
                img.AddCssClass("img-responsive");
            }
            else
            if (item is Conditioner)
            {
                img.Attributes.Add("data-action", "Conditioner");
                img.Attributes.Add("data-on", "/Content/Images/Cond_on.jpg");
                img.Attributes.Add("data-off", "/Content/Images/Cond.jpg");
                if (item.State)
                {
                    img.Attributes.Add("src", "/Content/Images/Cond_on.jpg");
                }
                else
                {
                    img.Attributes.Add("src", "/Content/Images/Cond.jpg");
                }
                img.AddCssClass("img-responsive");
                additionalResult += TemperatureDeviceBuilder((ITemperatureRegulator)item, id);
            }
            else
            if (item is Exhauster)
            {
                img.Attributes.Add("data-action", "Exhauster");
                img.Attributes.Add("data-on", "/Content/Images/Exhauster_on.jpg");
                img.Attributes.Add("data-off", "/Content/Images/Exhauster.jpg");
                if (item.State)
                {
                    img.Attributes.Add("src", "/Content/Images/Exhauster_on.jpg");
                }
                else
                {
                    img.Attributes.Add("src", "/Content/Images/Exhauster.jpg");
                }
                img.AddCssClass("img-responsive");
                additionalResult += PowerDeviceBuilder((IPowerRegulator)item, id);
            }
            else
            if (item is Fridge)
            {
                img.Attributes.Add("data-action", "Fridge");
                img.Attributes.Add("data-on", "/Content/Images/Fridge_on.jpg");
                img.Attributes.Add("data-off", "/Content/Images/Fridge.jpg");
                if (item.State)
                {
                    img.Attributes.Add("src", "/Content/Images/Fridge_on.jpg");
                }
                else
                {
                    img.Attributes.Add("src", "/Content/Images/Fridge.jpg");
                }
                img.AddCssClass("img-responsive");
                additionalResult += TemperatureDeviceBuilder((ITemperatureRegulator)item, id);
            }
            else
            if (item is Jalousie)
            {
                img.Attributes.Add("data-action", "Jalousie");
                img.Attributes.Add("data-on", "/Content/Images/Jalousie.jpg");
                img.Attributes.Add("data-off", "/Content/Images/Jalousie_off.jpg");
                if (item.State)
                {
                    img.Attributes.Add("src", "/Content/Images/Jalousie.jpg");
                }
                else
                {
                    img.Attributes.Add("src", "/Content/Images/Jalousie_off.jpg");
                }
                img.AddCssClass("img-responsive");
            }
            else
            if (item is Lamp)
            {
                img.Attributes.Add("data-action", "Lamp");
                img.AddCssClass("img-responsive");

                Lamp lamp = (Lamp)item;
                if (lamp.LampType == LampTypes.Chandelier.ToString())
                {
                    img.Attributes.Add("data-on", "/Content/Images/Lamp_on.jpg");
                    img.Attributes.Add("data-off", "/Content/Images/Lamp.jpg");
                    if (item.State)
                    {
                        img.Attributes.Add("src", "/Content/Images/Lamp_on.jpg");
                    }
                    else
                    {
                        img.Attributes.Add("src", "/Content/Images/Lamp.jpg");
                    }
                }
                else
                if (lamp.LampType == LampTypes.Table.ToString())
                {
                    img.Attributes.Add("data-on", "/Content/Images/Lamp_table_on.jpg");
                    img.Attributes.Add("data-off", "/Content/Images/Lamp_table.jpg");
                    if (item.State)
                    {
                        img.Attributes.Add("src", "/Content/Images/Lamp_table_on.jpg");
                    }
                    else
                    {
                        img.Attributes.Add("src", "/Content/Images/Lamp_table.jpg");
                    }
                }
                else
                if (lamp.LampType == LampTypes.Wall.ToString())
                {
                    img.Attributes.Add("data-on", "/Content/Images/Lamp_wall_on.jpg");
                    img.Attributes.Add("data-off", "/Content/Images/Lamp_wall.jpg");
                    if (item.State)
                    {
                        img.Attributes.Add("src", "/Content/Images/Lamp_wall_on.jpg");
                    }
                    else
                    {
                        img.Attributes.Add("src", "/Content/Images/Lamp_wall.jpg");
                    }
                }
                else
                if (lamp.LampType == LampTypes.Floor.ToString())
                {
                    img.Attributes.Add("data-on", "/Content/Images/Lamp_floor_on.jpg");
                    img.Attributes.Add("data-off", "/Content/Images/Lamp_floor.jpg");
                    if (item.State)
                    {
                        img.Attributes.Add("src", "/Content/Images/Lamp_floor_on.jpg");
                    }
                    else
                    {
                        img.Attributes.Add("src", "/Content/Images/Lamp_floor.jpg");
                    }
                }
                additionalResult += LightDeviceBuilder((ILightRegulator)item, id);
            }
            else
            if (item is Radiator)
            {
                img.Attributes.Add("data-action", "Radiator");
                img.Attributes.Add("data-on", "/Content/Images/Radiator_on.jpg");
                img.Attributes.Add("data-off", "/Content/Images/Radiator.jpg");
                if (item.State)
                {
                    img.Attributes.Add("src", "/Content/Images/Radiator_on.jpg");
                }
                else
                {
                    img.Attributes.Add("src", "/Content/Images/Radiator.jpg");
                }
                img.AddCssClass("img-responsive");
                additionalResult += TemperatureDeviceBuilder((ITemperatureRegulator)item, id);
            }
            else
            if (item is Router)
            {
                img.Attributes.Add("data-action", "Router");
                img.Attributes.Add("data-on", "/Content/Images/Router_on.jpg");
                img.Attributes.Add("data-off", "/Content/Images/Router.jpg");
                if (item.State)
                {
                    img.Attributes.Add("src", "/Content/Images/Router_on.jpg");
                }
                else
                {
                    img.Attributes.Add("src", "/Content/Images/Router.jpg");
                }
                img.AddCssClass("img-responsive");
            }
            else
            if (item is StereoSystem)
            {
                img.Attributes.Add("data-action", "StereoSystem");
                img.Attributes.Add("data-on", "/Content/Images/StereoSystem_on.jpg");
                img.Attributes.Add("data-off", "/Content/Images/StereoSystem.jpg");
                if (item.State)
                {
                    img.Attributes.Add("src", "/Content/Images/StereoSystem_on.jpg");
                }
                else
                {
                    img.Attributes.Add("src", "/Content/Images/StereoSystem.jpg");
                }
                img.AddCssClass("img-responsive");
                additionalResult += SoundDeviceBuilder((ISoundRegulator)item, id);
            }
            else
            if (item is TV)
            {
                img.Attributes.Add("data-action", "TV");
                img.Attributes.Add("data-on", "/Content/Images/TV_on.jpg");
                img.Attributes.Add("data-off", "/Content/Images/TV.jpg");
                if (item.State)
                {
                    img.Attributes.Add("src", "/Content/Images/TV_on.jpg");
                }
                else
                {
                    img.Attributes.Add("src", "/Content/Images/TV.jpg");
                }
                img.AddCssClass("img-responsive");
                additionalResult += SoundDeviceBuilder((ISoundRegulator)item, id);
                additionalResult += LightDeviceBuilder((ILightRegulator)item, id);
                additionalResult += ChannelDeviceBuilder((IChannels)item, id);
            }
            else { }

            result += img.ToString();
            input.AddCssClass("my-switch");
            if (item.State)
            {
                input.Attributes.Add("checked", "true");
            }
            else { }
            result += input.ToString(TagRenderMode.SelfClosing);
            TagBuilder label = new TagBuilder("label");
            label.AddCssClass("payt-label");
            label.Attributes.Add("for", item.Id.ToString() + " " + item.GetType().ToString() + " " + roomId);
            result += label.ToString();
            result += additionalResult;
            return new MvcHtmlString(result);
        }

        private static string ChannelDeviceBuilder(IChannels item, string id)
        {
            string result = null;
            TagBuilder h = new TagBuilder("h5");
            h.SetInnerText("Канал");
            h.AddCssClass("text-left");
            result += h.ToString();
            TagBuilder p = new TagBuilder("p");
            p.AddCssClass("btn");
            p.Attributes.Add("style", "padding: 2px 7px");
            TagBuilder span = new TagBuilder("span");
            span.AddCssClass("glyphicon glyphicon-minus");
            p.Attributes.Add("id", "channel " + "minus");
            p.InnerHtml += span.ToString();
            result += p.ToString();
            TagBuilder input = new TagBuilder("input");
            input.Attributes.Add("type", "text");
            input.Attributes.Add("style", "width: 65px; text-align:center");
            input.Attributes.Add("value", item.GetCurrentChannelName());
            input.Attributes.Add("id", id + " " + "channel");
            result += input.ToString();
            TagBuilder p2 = new TagBuilder("p");
            p2.AddCssClass("btn");
            p2.Attributes.Add("style", "padding: 2px 7px");
            TagBuilder span2 = new TagBuilder("span");
            span2.AddCssClass("glyphicon glyphicon-plus");
            p2.Attributes.Add("id", "channel " + "plus");
            p2.InnerHtml += span2.ToString();
            result += p2.ToString();
            return result;
        }
        private static string TemperatureDeviceBuilder(ITemperatureRegulator item, string id)
        {
            string result = null;
            TagBuilder h = new TagBuilder("h5");
            h.SetInnerText("Температура");
            h.AddCssClass("text-left");
            result += h.ToString();
            TagBuilder p = new TagBuilder("p");
            p.AddCssClass("btn");
            p.Attributes.Add("style", "padding: 2px 7px");
            TagBuilder span = new TagBuilder("span");
            span.AddCssClass("glyphicon glyphicon-minus");
            p.Attributes.Add("id", "temperature " + "minus");
            p.InnerHtml += span.ToString();
            result += p.ToString();
            TagBuilder input = new TagBuilder("input");
            input.Attributes.Add("type", "text");
            input.Attributes.Add("style", "width: 65px; text-align: center");
            input.Attributes.Add("value", item.CurrentTemperature.ToString());
            input.Attributes.Add("id", id + " " + "temperature");
            result += input.ToString();
            TagBuilder p2 = new TagBuilder("p");
            p2.AddCssClass("btn");
            p2.Attributes.Add("style", "padding: 2px 7px");
            TagBuilder span2 = new TagBuilder("span");
            span2.AddCssClass("glyphicon glyphicon-plus");
            p2.Attributes.Add("id", "temperature " + "plus");
            p2.InnerHtml += span2.ToString();
            result += p2.ToString();
            return result;
        }
        private static string PowerDeviceBuilder(IPowerRegulator item, string id)
        {
            string result = null;
            TagBuilder h = new TagBuilder("h5");
            h.SetInnerText("Мощность");
            h.AddCssClass("text-left");
            result += h.ToString();
            TagBuilder p = new TagBuilder("p");
            p.AddCssClass("btn");
            p.Attributes.Add("style", "padding: 2px 7px");
            TagBuilder span = new TagBuilder("span");
            span.AddCssClass("glyphicon glyphicon-minus");
            p.Attributes.Add("id", "power " + "minus");
            p.InnerHtml += span.ToString();
            result += p.ToString();
            TagBuilder input = new TagBuilder("input");
            input.Attributes.Add("type", "text");
            input.Attributes.Add("style", "width: 65px; text-align: center");
            input.Attributes.Add("value", item.CurrentPower.ToString());
            input.Attributes.Add("id", id + " " + "power");
            result += input.ToString();
            TagBuilder p2 = new TagBuilder("p");
            p2.AddCssClass("btn");
            p2.Attributes.Add("style", "padding: 2px 7px");
            TagBuilder span2 = new TagBuilder("span");
            span2.AddCssClass("glyphicon glyphicon-plus");
            p2.Attributes.Add("id", "power " + "plus");
            p2.InnerHtml += span2.ToString();
            result += p2.ToString();
            return result;
        }
        private static string LightDeviceBuilder(ILightRegulator item, string id)
        {
            string result = null;
            TagBuilder h = new TagBuilder("h5");
            h.SetInnerText("Яркость");
            h.AddCssClass("text-left");
            result += h.ToString();
            TagBuilder p = new TagBuilder("p");
            p.AddCssClass("btn");
            p.Attributes.Add("style", "padding: 2px 7px");
            TagBuilder span = new TagBuilder("span");
            span.AddCssClass("glyphicon glyphicon-minus");
            p.Attributes.Add("id", "brightness " + "minus");
            p.InnerHtml += span.ToString();
            result += p.ToString();
            TagBuilder input = new TagBuilder("input");
            input.Attributes.Add("type", "text");
            input.Attributes.Add("style", "width: 65px; text-align: center");
            input.Attributes.Add("value", item.CurrentBrightness.ToString());
            input.Attributes.Add("id", id + " " + "brightness");
            result += input.ToString();
            TagBuilder p2 = new TagBuilder("p");
            p2.AddCssClass("btn");
            p2.Attributes.Add("style", "padding: 2px 7px");
            TagBuilder span2 = new TagBuilder("span");
            span2.AddCssClass("glyphicon glyphicon-plus");
            p2.Attributes.Add("id", "brightness " + "plus");
            p2.InnerHtml += span2.ToString();
            result += p2.ToString();
            return result;
        }
        private static string SoundDeviceBuilder(ISoundRegulator item, string id)
        {
            string result = null;
            TagBuilder h = new TagBuilder("h5");
            h.SetInnerText("Громкость");
            h.AddCssClass("text-left");
            result += h.ToString();
            TagBuilder p = new TagBuilder("p");
            p.AddCssClass("btn");
            p.Attributes.Add("style", "padding: 2px 7px");
            TagBuilder span = new TagBuilder("span");
            span.AddCssClass("glyphicon glyphicon-minus");
            p.Attributes.Add("id", "volume " + "minus");
            p.InnerHtml += span.ToString();
            result += p.ToString();
            TagBuilder input = new TagBuilder("input");
            input.Attributes.Add("type", "text");
            input.Attributes.Add("style", "width: 65px; text-align: center");
            input.Attributes.Add("value", item.CurrentVolume.ToString());
            input.Attributes.Add("id", id + " " + "volume");
            result += input.ToString();
            TagBuilder p2 = new TagBuilder("p");
            p2.AddCssClass("btn");
            p2.Attributes.Add("style", "padding: 2px 7px");
            TagBuilder span2 = new TagBuilder("span");
            span2.AddCssClass("glyphicon glyphicon-plus");
            p2.Attributes.Add("id", "volume " + "plus");
            p2.InnerHtml += span2.ToString();
            result += p2.ToString();
            return result;
        }
    }
}