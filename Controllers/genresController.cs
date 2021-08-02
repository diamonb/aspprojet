using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using biblioteque.Models;

namespace biblioteque.Controllers
{
    public class genresController : Controller
    {
        private bibliotEntities db = new bibliotEntities();

        // GET: genres
        public ActionResult Index()
        {
            var genre = db.genre.Include(g => g.courant_litteraire);
            return View(genre.ToList());
        }

        // GET: genres/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            genre genre = db.genre.Find(id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }

        // GET: genres/Create
        public ActionResult Create()
        {
            ViewBag.id_courant_lit = new SelectList(db.courant_litteraire, "id_courant_lit", "libelle_courant_lit");
            return View();
        }

        // POST: genres/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_genre,libelle_genre,id_courant_lit")] genre genre)
        {
            if (ModelState.IsValid)
            {
                db.genre.Add(genre);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_courant_lit = new SelectList(db.courant_litteraire, "id_courant_lit", "libelle_courant_lit", genre.id_courant_lit);
            return View(genre);
        }

        // GET: genres/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            genre genre = db.genre.Find(id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_courant_lit = new SelectList(db.courant_litteraire, "id_courant_lit", "libelle_courant_lit", genre.id_courant_lit);
            return View(genre);
        }

        // POST: genres/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_genre,libelle_genre,id_courant_lit")] genre genre)
        {
            if (ModelState.IsValid)
            {
                db.Entry(genre).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_courant_lit = new SelectList(db.courant_litteraire, "id_courant_lit", "libelle_courant_lit", genre.id_courant_lit);
            return View(genre);
        }

        // GET: genres/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            genre genre = db.genre.Find(id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }

        // POST: genres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            genre genre = db.genre.Find(id);
            db.genre.Remove(genre);
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
    }
}
