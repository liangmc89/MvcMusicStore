using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcMusicStore.Models;

namespace MvcMusicStore.Controllers
{
    public class StoreController : Controller
    {
        // GET: Store
        public ActionResult Index()
        {
            var ablums = GetAblum();
            return View(ablums);
        }

        [Authorize]
        public ActionResult Buy(int id)
        {
            var ablums = GetAblum().Single(a => a.AblumId == id);
            return View(ablums);
        }

        private static List<Models.Ablum> GetAblum() {
            var ablums = new List<Ablum>()
            {
                new Ablum(){ AblumId=2,Price=100m,Title="The fall of math" },
                new Ablum(){ AblumId=3,Price=111m,Title="The blue notebooks"},
                new Ablum(){ AblumId=4,Price=99.9m,Title="Lose in Translation"},
                new Ablum(){ AblumId=5,Price=10.44m,Title="Permutation"}
            };
            return ablums;
        }

        
    }
}