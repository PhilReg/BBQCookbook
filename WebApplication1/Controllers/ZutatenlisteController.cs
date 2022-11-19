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
    public class ZutatenlisteController : BaseController
    {
        private Model1Container db = new Model1Container();

        // GET: Zutatenliste
        public ActionResult Index()
        {
            return View(db.ZutatenSet.ToList());
        }

        // GET: Zutatenliste/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zutaten zutaten = db.ZutatenSet.Find(id);
            if (zutaten == null)
            {
                return HttpNotFound();
            }
            return View(zutaten);
        }

        // GET: Zutatenliste/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Zutatenliste/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Zutatennamen,Kategorie")] Zutaten zutaten)
        {
            if (ModelState.IsValid)
            {
                db.ZutatenSet.Add(zutaten);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(zutaten);
        }

        // GET: Zutatenliste/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zutaten zutaten = db.ZutatenSet.Find(id);
            if (zutaten == null)
            {
                return HttpNotFound();
            }
            return View(zutaten);
        }

        // POST: Zutatenliste/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Zutatennamen,Kategorie")] Zutaten zutaten)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zutaten).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(zutaten);
        }

        // GET: Zutatenliste/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zutaten zutaten = db.ZutatenSet.Find(id);
            if (zutaten == null)
            {
                return HttpNotFound();
            }
            return View(zutaten);
        }

        // POST: Zutatenliste/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Zutaten zutaten = db.ZutatenSet.Find(id);
            db.ZutatenSet.Remove(zutaten);
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
