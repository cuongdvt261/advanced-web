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
        public ActionResult Index(int Id)
        {
            ViewBag.CatId = Id;
            return View(ProductDAO.Instance.GetProductToList());
        }

        public ActionResult ProductIndexPartial()
        {
            return PartialView(ProductDAO.Instance.GetProductToList());
        }

        public ActionResult ProductByCatIdPartial(int Id, int count)
        {
            return PartialView(ProductDAO.Instance.GetProductByCatIdTakeCountToList(Id, count));
        }

        public ActionResult ProductByCatIdSortPartial(int Id, int sortOrder)
        {
            return PartialView(ProductDAO.Instance.GetProductByCatIdOrderToList(Id, sortOrder));
        }

        public ActionResult NewMenProduct()
        {
            return PartialView(ProductDAO.Instance.GetNewManProduct());
        }

        public ActionResult NewWomanProduct()
        {
            return PartialView(ProductDAO.Instance.GetNewWomanProduct());
        }
    }
}