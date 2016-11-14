using AdvancedWeb.Models;
using AdvancedWeb.Models.DAO;
using AdvancedWeb.Models.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdvancedWeb.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Page404()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult LoginPartial()
        {
            return PartialView();
        }

        [HttpPost]
        public String GetLogin(String uname, String upass)
        {
            Session[Constants.LOGIN_SESSION] = uname;
            return UserDAO.Instance.CheckLogin(uname, upass) ? "success" : "fail";
        }

        #region TestDate
        public ActionResult TestData()
        {
            List<FakeData> lstData = GetData();
            var menu = from m in lstData
                       where m.ParentId == 0
                       select m;
            return PartialView(menu.ToList());
        }

        [ChildActionOnly]
        public PartialViewResult ChildrenMenu(int ParentId)
        {
            List<FakeData> lstData = GetData();
            var menu = from m in lstData
                       where m.ParentId == ParentId
                       select m;
            return PartialView(menu.ToList());
        }

        public List<FakeData> GetData()
        {
            return new List<FakeData>(){
                new FakeData(1, "Đồ nam", 0),
                new FakeData(2, "Quần nam", 1),
                new FakeData(3, "Áo nam", 1),
                new FakeData(4, "Quần đùi", 2),
                new FakeData(5, "Đồ nữ", 0),
                new FakeData(6, "Quần nữ", 5)
            };
        }
        #endregion
    }
}