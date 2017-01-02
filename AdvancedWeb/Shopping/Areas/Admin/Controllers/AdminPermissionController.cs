using Shopping.Areas.Admin.Models.DAO;
using Shopping.Areas.Admin.Models.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shopping.Areas.Admin.Controllers
{
    public class AdminPermissionController : Controller
    {
        // GET: Admin/AdminPermission
        public ActionResult Index()
        {
            return View(AdminPermissionDAO.Instance.GetListRole());
        }

        public ActionResult AddRole()
        {
            return View();
        }

        public JsonResult GetAction(String ctr)
        {
            return Json(Reflection.GetActionNames(ctr), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public String SetRole(String rName, String rDescription)
        {
            return AdminRoleDAO.Instance.SetRole(rName, rDescription);
        } 
    }
}