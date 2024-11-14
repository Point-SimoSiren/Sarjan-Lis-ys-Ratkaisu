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
    public class TreenihistoriaController : Controller
    {
        private TreenausDBEntities db = new TreenausDBEntities();



        //----------------LUODAAN LOMAKE SARJAN LISÄÄMISTÄ VARTEN---------------------------------------------------------------------
        // ------ Treenihistorian id tulee parametrina TREENIHISTORIA / INDEX.CSHTML SIVULTA

        public ActionResult Sarja(int? id)
        {
            ViewBag.TreeniId = id;
            return View();
        }

      

        // ----------- SARJAN LISÄYS HTTP POST -------------------------------

     
        [HttpPost]
        public ActionResult Sarja(Treenihistoriarivit treenihistoriarivit)
        {
          
                db.Treenihistoriarivit.Add(treenihistoriarivit);
                db.SaveChanges();
                return RedirectToAction("Index");

        }


        //----------------------------------------------------------------------------------------------------



        // GET: Treenihistoria
        public ActionResult Index()
        {
            return View(db.Treenihistoria.ToList());
        }

        // GET: Treenihistoria/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Treenihistoria treenihistoria = db.Treenihistoria.Find(id);
            if (treenihistoria == null)
            {
                return HttpNotFound();
            }
            return View(treenihistoria);
        }

        // GET: Treenihistoria/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: Treenihistoria/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TreenihistoriaID,Pvm")] Treenihistoria treenihistoria)
        {
            if (ModelState.IsValid)
            {
                db.Treenihistoria.Add(treenihistoria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(treenihistoria);
        }

        // GET: Treenihistoria/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Treenihistoria treenihistoria = db.Treenihistoria.Find(id);
            if (treenihistoria == null)
            {
                return HttpNotFound();
            }
            return View(treenihistoria);
        }

        // POST: Treenihistoria/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TreenihistoriaID,Pvm")] Treenihistoria treenihistoria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(treenihistoria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(treenihistoria);
        }

        // GET: Treenihistoria/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Treenihistoria treenihistoria = db.Treenihistoria.Find(id);
            if (treenihistoria == null)
            {
                return HttpNotFound();
            }
            return View(treenihistoria);
        }

        // POST: Treenihistoria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Treenihistoria treenihistoria = db.Treenihistoria.Find(id);
            db.Treenihistoria.Remove(treenihistoria);
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
