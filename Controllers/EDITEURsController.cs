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
    public class EDITEURsController : Controller
    {
        private bibliotEntities db = new bibliotEntities();

        // GET: EDITEURs
        public ActionResult Index()
        {
            return View(db.EDITEUR.ToList());
        }

        // GET: EDITEURs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EDITEUR eDITEUR = db.EDITEUR.Find(id);
            if (eDITEUR == null)
            {
                return HttpNotFound();
            }
            return View(eDITEUR);
        }

        // GET: EDITEURs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EDITEURs/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_editeur,nom_editeur")] EDITEUR eDITEUR)
        {
            if (ModelState.IsValid)
            {
                db.EDITEUR.Add(eDITEUR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eDITEUR);
        }

        // GET: EDITEURs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EDITEUR eDITEUR = db.EDITEUR.Find(id);
            if (eDITEUR == null)
            {
                return HttpNotFound();
            }
            return View(eDITEUR);
        }

        // POST: EDITEURs/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_editeur,nom_editeur")] EDITEUR eDITEUR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eDITEUR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eDITEUR);
        }

        // GET: EDITEURs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EDITEUR eDITEUR = db.EDITEUR.Find(id);
            if (eDITEUR == null)
            {
                return HttpNotFound();
            }
            return View(eDITEUR);
        }

        // POST: EDITEURs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EDITEUR eDITEUR = db.EDITEUR.Find(id);
            db.EDITEUR.Remove(eDITEUR);
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
