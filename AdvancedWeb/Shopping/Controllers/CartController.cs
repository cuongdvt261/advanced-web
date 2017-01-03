﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shopping.Models.DataModel;
using Shopping.Models.Helper;

namespace Shopping.Controllers
{
    public class CartController : Controller
    {
        private DataShop db = new DataShop();
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }

        public List<ShoppingCart> GetCart()
        {
            List<ShoppingCart> lstCart = Session[Constants.SESSION_CART_NAME] as List<ShoppingCart>;
            if (lstCart == null)
            {
                lstCart = new List<ShoppingCart>();
                Session[Constants.SESSION_CART_NAME] = lstCart;
            }
            return lstCart;
        }

        //Add Shopping Cart
        public ActionResult AddToCart(int productId, string strUrl)
        {
            Product _products = db.Products.SingleOrDefault(x => x.Id == productId);
            if (_products == null)
                return HttpNotFound();

            ShoppingCart _cart = GetCart().Find(x => x.ProductId == productId);
            if (_cart == null)
            {
                GetCart().Add(new ShoppingCart(productId));
            }
            else
            {
                _cart.Quantity++;
            }
            return Redirect(strUrl);
        }

        //Update Shopping Cart
        public ActionResult UpdateShoppingCart(int _idProduct, FormCollection _form)
        {
            Product _product = db.Products.SingleOrDefault(x => x.Id == _idProduct);
            if (_product == null)
                return HttpNotFound();

            ShoppingCart _cart = GetCart().SingleOrDefault(x => x.ProductId == _idProduct);
            if (_cart != null)
            {
                _cart.Quantity = int.Parse(_form["txtSoLuong"].ToString());
            }
            return RedirectToAction("ShoppingCart");
        }

        //Delete Shopping Cart
        public ActionResult DeleteCart(int productId)
        {
            Product _product = db.Products.SingleOrDefault(x => x.Id == productId);
            if (_product == null)
                return HttpNotFound();

            ShoppingCart _cart = GetCart().SingleOrDefault(x => x.ProductId == productId);
            if (_cart != null)
                GetCart().RemoveAll(x => x.ProductId == productId);

            return GetCart().Count() == 0 ? RedirectToAction("Index", "Home") : RedirectToAction("Checkout");
        }

        //Trang giỏ hàng
        public ActionResult Checkout()
        {
            if (Session[Constants.SESSION_CART_NAME] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.TongTien = GetSum();
                return View(GetCart());
            }
        }

        //Create Shopping Cart Partial
        public ActionResult CartPartial()
        {
            ViewBag.TongTien = GetSum();
            ViewBag.TongSoLuong = GetQuantity();
            return PartialView(GetCart());
        }

        public double GetSum()
        {
            return GetCart() != null ? GetCart().Sum(p => p.Total) : 0;
        }

        public int GetQuantity()
        {
            return GetCart() == null ? 0 : GetCart().Sum(x => x.Quantity);
        }
    }
}