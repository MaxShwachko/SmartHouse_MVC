using SmartHouse_MVC.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartHouse_MVC.Helpers
{
    public static class RoomBuilder
    {
        public static MvcHtmlString AnyRoomBuilder(this HtmlHelper html, Room item)
        {
            string result = null;
            TagBuilder h = new TagBuilder("h3");
            h.AddCssClass("text-center");
            h.SetInnerText(item.Name);
            result += h.ToString();
            TagBuilder a = new TagBuilder("a");
            a.Attributes.Add("href", "/SmartHouse/RoomInfo/" + @item.Id);
            TagBuilder img = new TagBuilder("img");
            img.Attributes.Add("src", "/Content/Images/door.jpg");
            img.AddCssClass("img-responsive");
            a.InnerHtml += img.ToString();
            result += a.ToString();
            TagBuilder p = new TagBuilder("p");
            result += p.ToString();
            return new MvcHtmlString(result);
        }
    }
}