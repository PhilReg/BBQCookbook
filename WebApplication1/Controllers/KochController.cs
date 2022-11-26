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
    public class KochController : BaseController
    {
        private Model1Container db = new Model1Container();

        // GET: Koch
        public ActionResult Index()
        {
            var kochSet = db.KochSet.Include(k => k.Bilder);
            if (hasUser() == false) 
            {
                return View(kochSet.ToList());
            }
            return View(kochSet.ToList());
        }

        // GET: Koch/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Koch koch = db.KochSet.Find(id);
            if (koch == null)
            {
                return HttpNotFound();
            }
            return View(koch);
        }

        // GET: Koch/Create
        public ActionResult Create()
        {
            ViewBag.BilderId = new SelectList(db.BilderSet, "Id", "Bildernamen");
            return View();
        }

        // POST: Koch/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Kochname,Kochbewertung,BilderId")] Koch koch)
        {
            if (ModelState.IsValid)
            {
                db.KochSet.Add(koch);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BilderId = new SelectList(db.BilderSet, "Id", "Bildernamen", koch.BilderId);
            return View(koch);
        }

        // GET: Koch/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Koch koch = db.KochSet.Find(id);
            if (koch == null)
            {
                return HttpNotFound();
            }
            ViewBag.BilderId = new SelectList(db.BilderSet, "Id", "Bildernamen", koch.BilderId);
            return View(koch);
        }

        // POST: Koch/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Kochname,Kochbewertung,BilderId")] Koch koch)
        {
            if (ModelState.IsValid)
            {
                db.Entry(koch).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BilderId = new SelectList(db.BilderSet, "Id", "Bildernamen", koch.BilderId);
            return View(koch);
        }

        // GET: Koch/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Koch koch = db.KochSet.Find(id);
            if (koch == null)
            {
                return HttpNotFound();
            }
            return View(koch);
        }

        // POST: Koch/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Koch koch = db.KochSet.Find(id);
            db.KochSet.Remove(koch);
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
        public ActionResult Vorerstellung()
        {
            return View();
        }
        public ActionResult UmleitungLogin()
        {
            return RedirectToAction("Create", "Koch");
        }
    }
}
