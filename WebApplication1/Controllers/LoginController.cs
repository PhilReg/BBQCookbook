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
    public class LoginController : BaseController
    {
        // GET: Login
        public ActionResult Index()
        {
            return View(db.KochSet.ToList());
        }

        // GET: Login/Details/5
        public ActionResult Select(int? Identification)
        {
            if (Identification == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Koch koch = db.KochSet.Find(Identification);
            if (koch == null)
            {
                return HttpNotFound();
            }
            setUserId(Identification.Value);
            setUser();
            return RedirectToAction("Index");
        }
    }
}
