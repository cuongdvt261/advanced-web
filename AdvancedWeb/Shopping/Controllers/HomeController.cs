using Shopping.Areas.Admin.Models.DAO;
using Shopping.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shopping.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection form)
        {
            String username = form["username"];
            String password = form["password"];
            if (UserDAO.Instance.isLogin(username, password))
            {
                Session["Login"] = AdminUserDAO.Instance.GetUserIdByUsername(username);
                return Redirect("/Home/Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Logout()
        {
            Session["Login"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}