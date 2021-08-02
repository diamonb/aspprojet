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
    public class courant_litteraireController : Controller
    {
        private bibliotEntities db = new bibliotEntities();

        // GET: courant_litteraire
        public ActionResult Index()
        {
            return View(db.courant_litteraire.ToList());
        }

        // GET: courant_litteraire/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            courant_litteraire courant_litteraire = db.courant_litteraire.Find(id);
            if (courant_litteraire == null)
            {
                return HttpNotFound();
            }
            return View(courant_litteraire);
        }

        // GET: courant_litteraire/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: courant_litteraire/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_courant_lit,libelle_courant_lit,description_courant_lit")] courant_litteraire courant_litteraire)
        {
            if (ModelState.IsValid)
            {
                db.courant_litteraire.Add(courant_litteraire);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(courant_litteraire);
        }

        // GET: courant_litteraire/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            courant_litteraire courant_litteraire = db.courant_litteraire.Find(id);
            if (courant_litteraire == null)
            {
                return HttpNotFound();
            }
            return View(courant_litteraire);
        }

        // POST: courant_litteraire/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_courant_lit,libelle_courant_lit,description_courant_lit")] courant_litteraire courant_litteraire)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courant_litteraire).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(courant_litteraire);
        }

        // GET: courant_litteraire/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            courant_litteraire courant_litteraire = db.courant_litteraire.Find(id);
            if (courant_litteraire == null)
            {
                return HttpNotFound();
            }
            return View(courant_litteraire);
        }

        // POST: courant_litteraire/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            courant_litteraire courant_litteraire = db.courant_litteraire.Find(id);
            db.courant_litteraire.Remove(courant_litteraire);
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
