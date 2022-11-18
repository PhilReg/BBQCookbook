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
    public class KochvorgangsController : BaseController
    {
        private Model1Container db = new Model1Container();

        // GET: Kochvorgangs
        public ActionResult Index()
        {
            var kochvorgangSet = db.KochvorgangSet.Include(k => k.Rezept).Include(k => k.Koch);
            return View(kochvorgangSet.ToList());
        }

        // GET: Kochvorgangs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kochvorgang kochvorgang = db.KochvorgangSet.Find(id);
            if (kochvorgang == null)
            {
                return HttpNotFound();
            }
            return View(kochvorgang);
        }

        // GET: Kochvorgangs/Create
        public ActionResult Create()
        {
            ViewBag.RezeptId = new SelectList(db.RezeptSet, "Id", "Rezeptnamen");
            ViewBag.KochId = new SelectList(db.KochSet, "Id", "Kochname");
            return View();
        }

        // POST: Kochvorgangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Protokoll,RezeptId,KochId")] Kochvorgang kochvorgang)
        {
            if (ModelState.IsValid)
            {
                db.KochvorgangSet.Add(kochvorgang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RezeptId = new SelectList(db.RezeptSet, "Id", "Rezeptnamen", kochvorgang.RezeptId);
            ViewBag.KochId = new SelectList(db.KochSet, "Id", "Kochname", kochvorgang.KochId);
            return View(kochvorgang);
        }

        // GET: Kochvorgangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kochvorgang kochvorgang = db.KochvorgangSet.Find(id);
            if (kochvorgang == null)
            {
                return HttpNotFound();
            }
            ViewBag.RezeptId = new SelectList(db.RezeptSet, "Id", "Rezeptnamen", kochvorgang.RezeptId);
            ViewBag.KochId = new SelectList(db.KochSet, "Id", "Kochname", kochvorgang.KochId);
            return View(kochvorgang);
        }

        // POST: Kochvorgangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Protokoll,RezeptId,KochId")] Kochvorgang kochvorgang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kochvorgang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RezeptId = new SelectList(db.RezeptSet, "Id", "Rezeptnamen", kochvorgang.RezeptId);
            ViewBag.KochId = new SelectList(db.KochSet, "Id", "Kochname", kochvorgang.KochId);
            return View(kochvorgang);
        }

        // GET: Kochvorgangs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kochvorgang kochvorgang = db.KochvorgangSet.Find(id);
            if (kochvorgang == null)
            {
                return HttpNotFound();
            }
            return View(kochvorgang);
        }

        // POST: Kochvorgangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kochvorgang kochvorgang = db.KochvorgangSet.Find(id);
            db.KochvorgangSet.Remove(kochvorgang);
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
