using BBQLibary;
using System;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class BaseController : Controller
    {
        protected Model1Container db =
              new Model1Container();
        private Koch _LoggedInKoch = null;
        protected Koch LoggedInKoch => _LoggedInKoch ?? setUser();
        private static String UserIDKey = "UserId";
        public Koch setUser()
        {
            int? userId = Session[UserIDKey] as int?;
            if (userId == null) return null;
            Koch res = db.KochSet.Find(userId);
            if (res == null) return null;
            ViewBag.User = res;
            _LoggedInKoch = res;
            return res;

        }
        protected bool hasUser()
        {
            return LoggedInKoch != null;

        }

        protected void setUserId(int userId)
        {
            Session[UserIDKey] = userId;
        }
    }
}