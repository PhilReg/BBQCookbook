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
    public class LoginController : Controller //Basis controller anlegen und davon erben
    {
        private Model1Container db = new Model1Container();

        // GET: Login
        public ActionResult Index()
        {
            return View(db.KochSet.ToList());
        }

        // GET: Login/Details/5
        public ActionResult Select(int? id)
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
            return Redirect("Index");
        }
    }
}
