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
    public class KochController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: Koch
        public ActionResult Index()
        {
            return View(db.KochSet.ToList());
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
            return View();
        }

        // POST: Koch/Create
        // Aktivieren Sie zum Schutz vor Angriffen durch Overposting die jeweiligen Eigenschaften, mit denen eine Bindung erfolgen soll. 
        // Weitere Informationen finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nutzerkennung,Equipment,Zutaten,Holz,Bewertung")] Koch koch)
        {
            koch.Bewertung = "keine Bewertung";
            if (ModelState.IsValid)
            {
                db.KochSet.Add(koch);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

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
            return View(koch);
        }

        // POST: Koch/Edit/5
        // Aktivieren Sie zum Schutz vor Angriffen durch Overposting die jeweiligen Eigenschaften, mit denen eine Bindung erfolgen soll. 
        // Weitere Informationen finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nutzerkennung,Equipment,Zutaten,Holz,Bewertung")] Koch koch)
        {
            if (ModelState.IsValid)
            {
                db.Entry(koch).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
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
    }
}
