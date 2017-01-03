using Shopping.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shopping.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult ProductIndex()
        {
            return PartialView(ProductDAO.Instance.GetListTakeNumberNotDeleteProduct(8));
        }

        public ActionResult ProductByCat(int Id)
        {
            ViewBag.CatId = Id;
            return View(ProductDAO.Instance.GetListProductByCatId(Id));
        }

        public PartialViewResult FilterProductPartial(int minPrice, int maxPrice, int catId)
        {
            return PartialView(ProductDAO.Instance.FilterProductByPrice(minPrice, maxPrice, catId));
        }

        public ActionResult Id(int Id)
        {
            return View(ProductDAO.Instance.GetProductById(Id));
        }
    }
}