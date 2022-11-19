using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ImpBBQLibary;

namespace WebApplication1.Controllers
{
    public class ImageController : Controller
    {
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
       [HttpPost]
        public ActionResult Add(Bilder imageModel)
            {
            string fileName = Path.GetFileNameWithoutExtension(imageModel.ImageFile.FileName);
            string extension = Path.GetExtension(imageModel.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            imageModel.ImagePath = "~/Images/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Images"), fileName);
            imageModel.ImageFile.SaveAs(fileName);
            using (Model1Container db = new Model1Container())
            {
                db.BilderSet.Add(imageModel);
                db.SaveChanges();
            }
            ModelState.Clear();
                return View();
            }
        
     }
}