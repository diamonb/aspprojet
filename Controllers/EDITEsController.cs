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
    public class EDITEsController : Controller
    {
        private bibliotEntities db = new bibliotEntities();

        // GET: EDITEs
        public ActionResult Index()
        {
            var eDITE = db.EDITE.Include(e => e.EDITEUR).Include(e => e.livre);
            return View(eDITE.ToList());
        }

        // GET: EDITEs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EDITE eDITE = db.EDITE.Find(id);
            if (eDITE == null)
            {
                return HttpNotFound();
            }
            return View(eDITE);
        }

        // GET: EDITEs/Create
        public ActionResult Create()
        {
            ViewBag.id_editeur = new SelectList(db.EDITEUR, "id_editeur", "nom_editeur");
            ViewBag.id_livre = new SelectList(db.livre, "id_livre", "nom_livre");
            return View();
        }

        // POST: EDITEs/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_livre,id_editeur,isbn,date_edition")] EDITE eDITE)
        {
            if (ModelState.IsValid)
            {
                db.EDITE.Add(eDITE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_editeur = new SelectList(db.EDITEUR, "id_editeur", "nom_editeur", eDITE.id_editeur);
            ViewBag.id_livre = new SelectList(db.livre, "id_livre", "nom_livre", eDITE.id_livre);
            return View(eDITE);
        }

        // GET: EDITEs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EDITE eDITE = db.EDITE.Find(id);
            if (eDITE == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_editeur = new SelectList(db.EDITEUR, "id_editeur", "nom_editeur", eDITE.id_editeur);
            ViewBag.id_livre = new SelectList(db.livre, "id_livre", "nom_livre", eDITE.id_livre);
            return View(eDITE);
        }

        // POST: EDITEs/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_livre,id_editeur,isbn,date_edition")] EDITE eDITE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eDITE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_editeur = new SelectList(db.EDITEUR, "id_editeur", "nom_editeur", eDITE.id_editeur);
            ViewBag.id_livre = new SelectList(db.livre, "id_livre", "nom_livre", eDITE.id_livre);
            return View(eDITE);
        }

        // GET: EDITEs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EDITE eDITE = db.EDITE.Find(id);
            if (eDITE == null)
            {
                return HttpNotFound();
            }
            return View(eDITE);
        }

        // POST: EDITEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EDITE eDITE = db.EDITE.Find(id);
            db.EDITE.Remove(eDITE);
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
