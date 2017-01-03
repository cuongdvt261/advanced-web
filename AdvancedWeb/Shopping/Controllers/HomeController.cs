using Shopping.Areas.Admin.Models.DAO;
using Shopping.Models.DAO;
using Shopping.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shopping.Models.Helper;

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
                Session[Constants.SESSION_LOGIN_NAME] = AdminUserDAO.Instance.GetUserIdByUsername(username);
                return Redirect("/Home/Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Logout()
        {
            Session[Constants.SESSION_LOGIN_NAME] = null;
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                UserDAO.Instance.DoRegister(user);
                Session[Constants.SESSION_LOGIN_NAME] = AdminUserDAO.Instance.GetUserIdByUsername(user.Username);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}