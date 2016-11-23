using AdvancedWeb.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdvancedWeb.Areas.Admin.Controllers
{
    public class StatisticsController : Controller
    {
        private DataReference db = new DataReference();

        // GET: Admin/Statistics
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public int GetCountUser()
        {
            return db.Users.Where(u => u.Deleted == false).Count();
        }

        [HttpPost]
        public int GetOrderCount()
        {
            return db.Orders.Where(o => o.Deleted == false).Count();
        }

        [HttpPost]
        public int GetProductCount()
        {
            return db.Products.Where(p => p.Deleted == false).Count();
        }
    }
}