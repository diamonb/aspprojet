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
    public class AUTEURsController : Controller
    {
        private bibliotEntities db = new bibliotEntities();

        // GET: AUTEURs
        public ActionResult Index()
        {
            return View(db.AUTEUR.ToList());
        }

        // GET: AUTEURs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AUTEUR aUTEUR = db.AUTEUR.Find(id);
            if (aUTEUR == null)
            {
                return HttpNotFound();
            }
            return View(aUTEUR);
        }

        // GET: AUTEURs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AUTEURs/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_auteur,nom_auteur,prenom_auteur")] AUTEUR aUTEUR)
        {
            if (ModelState.IsValid)
            {
                db.AUTEUR.Add(aUTEUR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aUTEUR);
        }

        // GET: AUTEURs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AUTEUR aUTEUR = db.AUTEUR.Find(id);
            if (aUTEUR == null)
            {
                return HttpNotFound();
            }
            return View(aUTEUR);
        }

        // POST: AUTEURs/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_auteur,nom_auteur,prenom_auteur")] AUTEUR aUTEUR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aUTEUR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aUTEUR);
        }

        // GET: AUTEURs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AUTEUR aUTEUR = db.AUTEUR.Find(id);
            if (aUTEUR == null)
            {
                return HttpNotFound();
            }
            return View(aUTEUR);
        }

        // POST: AUTEURs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AUTEUR aUTEUR = db.AUTEUR.Find(id);
            db.AUTEUR.Remove(aUTEUR);
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
