using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shopping.Areas.Admin.Models.DAO;
using Shopping.Areas.Admin.Models.Helper;

namespace Shopping.Areas.Admin.Controllers
{
    [Author]
    public class UserGroupRoleController : Controller
    {
        // GET: Admin/UserGroupRole
        public ActionResult Index()
        {
            if (Session["AdminLogin"] == null)
                return RedirectToAction("AdminLogin", "AdminHome");
            else
                return View();
        }

        public ActionResult Role(int Id)
        {
            ViewBag.ugId = Id;
            return View(AdminRoleDAO.Instance.GetRoleByUserGroup(Id));
        }

        [HttpPost]
        public String SetRoleForUserGroup(int uGroupId, int roleId, bool isChecked)
        {
            if (isChecked)
            {
                AdminRoleDAO.Instance.SetRoleByUserGroup(uGroupId, roleId);
                return "Insert Success";
            }
            else
            {
                AdminRoleDAO.Instance.RemoveRoleByUserGroup(uGroupId, roleId);
                return "Delete Success";
            }
        }
    }
}