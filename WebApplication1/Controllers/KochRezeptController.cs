using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ImpBBQLibary;

namespace WebApplication1.Controllers
{
    public class KochRezeptController : BaseController
    {
        private Model1Container db = new Model1Container();

        // GET: KochRezept
        public ActionResult Index()
        {
            return View(db.RezeptSet.ToList());
        }

        // GET: KochRezept/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rezept rezept = db.RezeptSet.Find(id);
            if (rezept == null)
            {
                return HttpNotFound();
            }
            return View(rezept);
        }

        // GET: KochRezept/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KochRezept/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Rezeptnamen,Vorgehen,Rezeptbewertung")] Rezept rezept)
        {
            if (ModelState.IsValid)
            {
                db.RezeptSet.Add(rezept);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rezept);
        }

        // GET: KochRezept/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rezept rezept = db.RezeptSet.Find(id);
            if (rezept == null)
            {
                return HttpNotFound();
            }
            return View(rezept);
        }

        // POST: KochRezept/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Rezeptnamen,Vorgehen,Rezeptbewertung")] Rezept rezept)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rezept).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rezept);
        }

        // GET: KochRezept/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rezept rezept = db.RezeptSet.Find(id);
            if (rezept == null)
            {
                return HttpNotFound();
            }
            return View(rezept);
        }

        // POST: KochRezept/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rezept rezept = db.RezeptSet.Find(id);
            db.RezeptSet.Remove(rezept);
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
        public ActionResult Rezpeterstellen(int? id)
        {
            if(id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rezept rezept = db.RezeptSet.Find(id);
            if (rezept == null)
            {
                return HttpNotFound();
            }
            if (!hasUser())
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoggedInKoch.Rezept.Add(rezept);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
