using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdvancedWeb.Areas.Admin.Models.DAO;
using System.Net;
using AdvancedWeb.Models.DataModel;
using System.Data.Entity;

namespace AdvancedWeb.Areas.Admin.Controllers
{
    public class AdminProductController : Controller
    {
        private DataReference db = new DataReference();

        // GET: Admin/AdminProduct
        public ActionResult Index()
        {
            return View(AdminProductDAO.Instance.GetProductToList());
        }

        // GET: Admin/Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", product.CategoryId);
            ViewBag.PromotionId = new SelectList(db.Promotions, "Id", "Name", product.PromotionId);
            return View(product);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Price,Quantity,Description,Image,CategoryId,CreatedDate,ModifiedDate,Deleted,TabIndex,PromotionId")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", product.CategoryId);
            ViewBag.PromotionId = new SelectList(db.Promotions, "Id", "Name", product.PromotionId);
            return View(product);
        }
    }
}