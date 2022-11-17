using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BBQLibary;

namespace WebApplication1.Controllers
{
    public class KochvorgangController : BaseController
    {
        private Model1Container db = new Model1Container();

        // GET: Kochvorgang
        public ActionResult Index()
        {
            var kochvorgangSet = db.KochvorgangSet.Include(k => k.Rezept);
            return View(kochvorgangSet.ToList());
        }

        // GET: Kochvorgang/Details/5
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

        // GET: Kochvorgang/Create
        public ActionResult Create()
        {
            ViewBag.RezeptId = new SelectList(db.RezeptSet, "Id", "Zutatenliste");
            return View();
        }

        // POST: Kochvorgang/Create
        // Aktivieren Sie zum Schutz vor Angriffen durch Overposting die jeweiligen Eigenschaften, mit denen eine Bindung erfolgen soll. 
        // Weitere Informationen finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Protokoll,RezeptId")] Kochvorgang kochvorgang)
        {
            if (ModelState.IsValid)
            {
                db.KochvorgangSet.Add(kochvorgang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RezeptId = new SelectList(db.RezeptSet, "Id", "Zutatenliste", kochvorgang.RezeptId);
            return View(kochvorgang);
        }

        // GET: Kochvorgang/Edit/5
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
            ViewBag.RezeptId = new SelectList(db.RezeptSet, "Id", "Zutatenliste", kochvorgang.RezeptId);
            return View(kochvorgang);
        }

        // POST: Kochvorgang/Edit/5
        // Aktivieren Sie zum Schutz vor Angriffen durch Overposting die jeweiligen Eigenschaften, mit denen eine Bindung erfolgen soll. 
        // Weitere Informationen finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Protokoll,RezeptId")] Kochvorgang kochvorgang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kochvorgang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RezeptId = new SelectList(db.RezeptSet, "Id", "Zutatenliste", kochvorgang.RezeptId);
            return View(kochvorgang);
        }

        // GET: Kochvorgang/Delete/5
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

        // POST: Kochvorgang/Delete/5
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
