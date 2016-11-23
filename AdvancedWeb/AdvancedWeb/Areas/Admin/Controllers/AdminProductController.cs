using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdvancedWeb.Areas.Admin.Models.DAO;
using System.Net;
using AdvancedWeb.Models.DataModel;

namespace AdvancedWeb.Areas.Admin.Controllers
{
    public class AdminProductController : Controller
    {
        // GET: Admin/AdminProduct
        public ActionResult Index()
        {
            return View(AdminProductDAO.Instance.GetProductToList());
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            return View(AdminProductDAO.Instance.GetProductInfo(id));
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Name,Price,Quantity,Description,Image,CategoryId,ModifiedDate,Deleted,TabIndex,PromotionId")] Product product)
        {
            if (ModelState.IsValid)
            {
                AdminProductDAO.Instance.EditProduct(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }
    }
}