using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMusicStore.Controllers
{
    public class StoreController : Controller
    {
        // GET: Store
        public string Index()
        {
            return "Hello from Store.index()";
        }

        public string  Browser(string genre)
        {
            string message = HttpUtility.HtmlEncode("Store.Browser,genre="+genre);
            return message;
        }

        public string Detail(int id) {
            string message = HttpUtility.HtmlEncode("Store.Browser,id="+id);
            return message;
        }
    }
}