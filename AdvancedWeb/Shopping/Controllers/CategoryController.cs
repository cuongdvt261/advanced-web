using Shopping.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shopping.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult CategoryPartial()
        {
            return PartialView(CategoryDAO.Instance.GetListCategory());
        }
    }
}