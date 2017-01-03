using Shopping.Areas.Admin.Models.DAO;
using Shopping.Areas.Admin.Models.Helper;
using Shopping.Models.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shopping.Areas.Admin.Controllers
{
    public class AdminHomeController : Controller
    {
        // GET: Admin/AdminHome
        public ActionResult Index()
        {
            if (Session["AdminLogin"] == null)
                return RedirectToAction("AdminLogin");
            else
                return View();
        }

        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(FormCollection form)
        {
            if (Session["AdminLogin"] != null)
            {
                return Redirect("/Admin/AdminHome/Index");
            }
            String username = form["username"];
            String password = form["password"];

            if (AdminUserDAO.Instance.isLogin(username, password))
            {
                Session["AdminLogin"] = AdminUserDAO.Instance.GetUserIdByUsername(username);
                return Redirect("/Admin/AdminHome/Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult AdminLogout()
        {
            Session["AdminLogin"] = null;
            Session[Constants.SESSION_LOGIN_NAME] = null;
            return RedirectToAction("Index", "AdminHome");
        }

        public ActionResult Warning()
        {
            return View();
        }
    }
}