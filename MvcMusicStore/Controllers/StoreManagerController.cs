using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcMusicStore.Models;

namespace MvcMusicStore.Controllers
{
    public class StoreManagerController : Controller
    {
        private MusicStoreDBContext db = new MusicStoreDBContext();

        // GET: StoreManager
        public ActionResult Index()
        {
            var ablums = db.Ablums.Include(a => a.Artist).Include(a => a.Genre);
            return View(ablums.ToList());
        }

        // GET: StoreManager/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ablum ablum = db.Ablums.Find(id);
            if (ablum == null)
            {
                return HttpNotFound();
            }
            return View(ablum);
        }

        // GET: StoreManager/Create
        public ActionResult Create()
        {
            ViewBag.ArtistId = new SelectList(db.Artists, "ArtistId", "Name");
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name");
            return View();
        }

        // POST: StoreManager/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AblumId,GenreId,ArtistId,Title,Price,AblumArtUrl")] Ablum ablum)
        {
            if (ModelState.IsValid)
            {
                db.Ablums.Add(ablum);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArtistId = new SelectList(db.Artists, "ArtistId", "Name", ablum.ArtistId);
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", ablum.GenreId);
            return View(ablum);
        }

        // GET: StoreManager/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ablum ablum = db.Ablums.Find(id);
            if (ablum == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArtistId = new SelectList(db.Artists, "ArtistId", "Name", ablum.ArtistId);
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", ablum.GenreId);
            return View(ablum);
        }

        // POST: StoreManager/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AblumId,GenreId,ArtistId,Title,Price,AblumArtUrl")] Ablum ablum)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ablum).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArtistId = new SelectList(db.Artists, "ArtistId", "Name", ablum.ArtistId);
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", ablum.GenreId);
            return View(ablum);
        }

        // GET: StoreManager/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ablum ablum = db.Ablums.Find(id);
            if (ablum == null)
            {
                return HttpNotFound();
            }
            return View(ablum);
        }

        // POST: StoreManager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ablum ablum = db.Ablums.Find(id);
            db.Ablums.Remove(ablum);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        public ActionResult Search(string q)
        {
            var ablums = db.Ablums.Include("Artist").Where(a => a.Title.Contains(q)).Take(10);
            return View(ablums);
        }

    }
}
