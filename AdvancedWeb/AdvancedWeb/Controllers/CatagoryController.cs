using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdvancedWeb.Models.DAO;

namespace AdvancedWeb.Controllers
{
    public class CatagoryController : Controller
    {
        // GET: Catagory
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CatagoryPartial()
        {
            return PartialView(CatagoryDAO.Instance.GetCatagoryToList());
        }
    }
}