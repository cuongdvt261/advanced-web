using Shopping.Areas.Admin.Models.DAO;
using Shopping.Areas.Admin.Models.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shopping.Areas.Admin.Controllers
{
    [Author]
    public class UserRoleController : Controller
    {
        // GET: Admin/UserRole
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Role(int Id)
        {
            ViewBag.UserId = Id;
            return View(AdminRoleDAO.Instance.GetAllRoleByUser(Id));
        }

        [HttpPost]
        public String SetRoleForUser(int userId, int roleId, bool isChecked)
        {
            if (isChecked)
            {
                AdminRoleDAO.Instance.SetRoleByUser(userId, roleId);
                return "Insert Success";
            }
            else
            {
                AdminRoleDAO.Instance.RemoveRoleByUser(userId, roleId);
                return "Delete Success";
            }
        }
    }
}