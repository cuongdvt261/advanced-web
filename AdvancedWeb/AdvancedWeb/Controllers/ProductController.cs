using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdvancedWeb.Models.Helper;
using AdvancedWeb.Models.DAO;

namespace AdvancedWeb.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProductIndexPartial()
        {
            return View(ProductDAO.Instance.GetProductToList());
        }
    }
}