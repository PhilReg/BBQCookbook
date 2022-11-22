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
    public class RezeptsController : BaseController
    {
        

        // GET: Rezepts
        public ActionResult Index()
        {
            return View(db.RezeptSet.ToList());
        }

        // GET: Rezepts/Details/5
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

        // GET: Rezepts/Create
        public ActionResult Create()
        {
            setUser();
            //ViewBag.KochID = new SelectList(db.KochSet, "Id", "Name");
            return View();
        }

        // POST: Rezepts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Rezeptnamen,Vorgehen,Rezeptbewertung,Koch")] Rezept rezept)
        {
            rezept.Koch = LoggedInKoch;
            if (ModelState.IsValid)
            { 
                setUser();
                db.RezeptSet.Add(rezept);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rezept);
        }

        // GET: Rezepts/Edit/5
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

        // POST: Rezepts/Edit/5
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

        // GET: Rezepts/Delete/5
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

        // POST: Rezepts/Delete/5
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
        public ActionResult ZutatenAuswählen(int? id)
        {
            Rezept aktuell = db.RezeptSet.Find(id);
            ViewBag.Rezept = aktuell.Rezeptnamen;
            ViewBag.Zutaten = new SelectList(db.ZutatenSet,"Id", "Zutatennamen");

            return View();
        }
           
    }
}
