using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shopping.Areas.Admin.Models.DAO
{
    public class AjaxController : Controller
    {
        // GET: Admin/Ajax
        public ActionResult Index()
        {
            return View();
        }
    }
}