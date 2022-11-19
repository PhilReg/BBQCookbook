using ImpBBQLibary;
using System;
using System.Linq;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class BaseController : Controller
    {
        protected Model1Container db =
              new Model1Container();
        private static String UserIdKey = "UserId";
        public Koch setUser()
        {
            int? userId = Session[UserIdKey] as int?;
            if (userId == null) return null;
            Koch res = db.KochSet.Find(userId);
            if (res == null) return null;
            ViewBag.CurrentUser = res.Kochname;
            _LoggedInKoch = res;
            return res;
        }
        private Koch _LoggedInKoch = null;
        protected Koch LoggedInKoch => _LoggedInKoch ?? setUser();
        protected bool hasUser()
        {
            return LoggedInKoch != null;

        }
        protected void setUserId(int userId)
        {
            Session[UserIdKey] = userId;
        }
        public ActionResult Show(int id)
        {
            Bilder imageModel = new Bilder();
            using (Model1Container db= new Model1Container())
            {
                imageModel = db.BilderSet.Where(x => x.Id == id).FirstOrDefault();
            }
            return File(imageModel.ImagePath, "image/jpg");
        }
    }

}