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
    public class livresController : Controller
    {
        private bibliotEntities db = new bibliotEntities();

        // GET: livres
        public ActionResult Index()
        {
            var livre = db.livre.Include(l => l.AUTEUR).Include(l => l.genre);
            return View(livre.ToList());
        }

        // GET: livres/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            livre livre = db.livre.Find(id);
            if (livre == null)
            {
                return HttpNotFound();
            }
            return View(livre);
        }

        // GET: livres/Create
        public ActionResult Create()
        {
            ViewBag.id_auteur = new SelectList(db.AUTEUR, "id_auteur", "nom_auteur");
            ViewBag.id_genre = new SelectList(db.genre, "id_genre", "libelle_genre");
            return View();
        }

        // POST: livres/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_livre,nom_livre,id_genre,id_auteur")] livre livre)
        {
            if (ModelState.IsValid)
            {
                db.livre.Add(livre);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_auteur = new SelectList(db.AUTEUR, "id_auteur", "nom_auteur", livre.id_auteur);
            ViewBag.id_genre = new SelectList(db.genre, "id_genre", "libelle_genre", livre.id_genre);
            return View(livre);
        }

        // GET: livres/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            livre livre = db.livre.Find(id);
            if (livre == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_auteur = new SelectList(db.AUTEUR, "id_auteur", "nom_auteur", livre.id_auteur);
            ViewBag.id_genre = new SelectList(db.genre, "id_genre", "libelle_genre", livre.id_genre);
            return View(livre);
        }

        // POST: livres/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_livre,nom_livre,id_genre,id_auteur")] livre livre)
        {
            if (ModelState.IsValid)
            {
                db.Entry(livre).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_auteur = new SelectList(db.AUTEUR, "id_auteur", "nom_auteur", livre.id_auteur);
            ViewBag.id_genre = new SelectList(db.genre, "id_genre", "libelle_genre", livre.id_genre);
            return View(livre);
        }

        // GET: livres/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            livre livre = db.livre.Find(id);
            if (livre == null)
            {
                return HttpNotFound();
            }
            return View(livre);
        }

        // POST: livres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            livre livre = db.livre.Find(id);
            db.livre.Remove(livre);
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
