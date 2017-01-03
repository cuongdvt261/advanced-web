using Shopping.Models.DAO;
using Shopping.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shopping.Controllers
{
    public class CommonController : Controller
    {
        // GET: Common
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public String CheckEmail(String email)
        {
            return UserDAO.Instance.IsEmailExist(email) ? "Yes" : "No";
        }

        [HttpPost]
        public String CheckUsername(String uName)
        {
            return UserDAO.Instance.IsUsernameExist(uName) ? "Yes" : "No";
        }

        [HttpPost]
        public JsonResult Search(String keyword)
        {
            using (DataShop db = new DataShop())
            {
                var _prodQuery = (from n in db.Products
                                  where n.Name.StartsWith(keyword) && n.Deleted != true
                                  select new { n.Name });
                return Json(_prodQuery, JsonRequestBehavior.AllowGet);
            }
        }
    }
}