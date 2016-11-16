using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdvancedWeb.Models.DataModel;
using AdvancedWeb.Models.DAO;

namespace AdvancedWeb.Controllers
{
    public class AjaxController : Controller
    {
        // GET: Ajax
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public void TakeCountProduct(int catId, int count)
        {
            ProductDAO.Instance.GetProductByCatIdTakeCountToList(catId, count);
        }
    }
}