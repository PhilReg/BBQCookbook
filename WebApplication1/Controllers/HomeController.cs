﻿using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            setUser();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult UmleitungLogin()
        {
            return RedirectToAction("Index", "Login");
        }
        public ActionResult UmleitungRegist()
        {
            return RedirectToAction("Create", "Koch");
        }
    }
}