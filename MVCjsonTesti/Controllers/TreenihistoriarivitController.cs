using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCjsonTesti.Models;

namespace MVCjsonTesti.Controllers
{
    public class TreenihistoriarivitController : Controller
    {
        private TreenausDBEntities db = new TreenausDBEntities();

        // GET: Treenihistoriarivit
        public ActionResult Index()
        {
            var treenihistoriarivit = db.Treenihistoriarivit.Include(t => t.Treenihistoria);
            return View(treenihistoriarivit.ToList());
        }

        // GET: Treenihistoriarivit/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Treenihistoriarivit treenihistoriarivit = db.Treenihistoriarivit.Find(id);
            if (treenihistoriarivit == null)
            {
                return HttpNotFound();
            }
            return View(treenihistoriarivit);
        }

  

        // SARJOJEN LISÄYS TAPAHTUU TOISESSA KONTROLLERISSA!!

        // SIKSI CREATE GET JA POST METODIT TREENIHISTORIARIVEILLE PUUTTUVAT TÄÄLTÄ




        // GET: Treenihistoriarivit/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Treenihistoriarivit treenihistoriarivit = db.Treenihistoriarivit.Find(id);
            if (treenihistoriarivit == null)
            {
                return HttpNotFound();
            }
            ViewBag.TreenihistoriaID = new SelectList(db.Treenihistoria, "TreenihistoriaID", "TreenihistoriaID", treenihistoriarivit.TreenihistoriaID);
            return View(treenihistoriarivit);
        }

        // POST: Treenihistoriarivit/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TreenihistoriariviID,TreenihistoriaID,LiikeID,Sarjat,Painot")] Treenihistoriarivit treenihistoriarivit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(treenihistoriarivit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TreenihistoriaID = new SelectList(db.Treenihistoria, "TreenihistoriaID", "TreenihistoriaID", treenihistoriarivit.TreenihistoriaID);
            return View(treenihistoriarivit);
        }

        // GET: Treenihistoriarivit/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Treenihistoriarivit treenihistoriarivit = db.Treenihistoriarivit.Find(id);
            if (treenihistoriarivit == null)
            {
                return HttpNotFound();
            }
            return View(treenihistoriarivit);
        }

        // POST: Treenihistoriarivit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Treenihistoriarivit treenihistoriarivit = db.Treenihistoriarivit.Find(id);
            db.Treenihistoriarivit.Remove(treenihistoriarivit);
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
