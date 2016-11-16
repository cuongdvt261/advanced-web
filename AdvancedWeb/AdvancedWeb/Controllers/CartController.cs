using AdvancedWeb.Models.DataModel;
using AdvancedWeb.Models.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdvancedWeb.Controllers
{
    public class CartController : Controller
    {
        private DataReference db = new DataReference();

        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }

        public List<ShoppingCart> GetCart()
        {
            List<ShoppingCart> lstCart = Session[Constants.CART_SESSION] as List<ShoppingCart>;
            if (lstCart == null)
            {
                lstCart = new List<ShoppingCart>();
                Session[Constants.CART_SESSION] = lstCart;
            }
            return lstCart;
        }

        //Add Shopping Cart
        public ActionResult AddToCart(int productId, string strUrl)
        {
            Product _products = db.Products.SingleOrDefault(x => x.Id == productId);
            if (_products == null)
            {
                return HttpNotFound();
            }

            List<ShoppingCart> _lstGioHang = GetCart();
            ShoppingCart _cart = _lstGioHang.Find(x => x.ProductId == productId);
            if (_cart == null)
            {
                _cart = new ShoppingCart(productId);
                //Thêm sản phẩm vào List
                _lstGioHang.Add(_cart);
                return Redirect(strUrl);
            }
            else
            {
                Product p = db.Products.Single(x => x.Id == productId);
                if (p.Quantity <= 1)
                {
                    _cart.Quantity = 1;
                }
                else
                {
                    _cart.Quantity++;
                }
                return Redirect(strUrl);
            }
        }

        //Update Shopping Cart
        public ActionResult UpdateShoppingCart(int _idProduct, FormCollection _form)
        {
            Product _product = db.Products.SingleOrDefault(x => x.Id == _idProduct);
            if (_product == null)
            {
                return HttpNotFound();
            }
            List<ShoppingCart> _lstGioHang = GetCart();
            ShoppingCart _cart = _lstGioHang.SingleOrDefault(x => x.ProductId == _idProduct);
            if (_cart != null)
            {
                _cart.Quantity = int.Parse(_form["txtSoLuong"].ToString());
            }
            return RedirectToAction("ShoppingCart");
        }

        //Delete Shopping Cart
        public ActionResult DeleteShoppingCart(int _idProduct)
        {
            Product _product = db.Products.SingleOrDefault(x => x.Id == _idProduct);
            if (_product == null)
            {
                return HttpNotFound();
            }
            List<ShoppingCart> _lstGioHang = GetCart();
            ShoppingCart _cart = _lstGioHang.SingleOrDefault(x => x.ProductId == _idProduct);
            if (_cart != null)
            {
                _lstGioHang.RemoveAll(x => x.ProductId == _idProduct);
            }
            if (_lstGioHang.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("ShoppingCart");
        }

        //Trang giỏ hàng
        public ActionResult ShoppingCart()
        {
            if (Session[Constants.CART_SESSION] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<ShoppingCart> _lstGioHang = GetCart();
            ViewBag.TongTien = GetSum();
            return View(_lstGioHang);
        }

        //Create Shopping Cart Partial
        public ActionResult CartPartial()
        {
            List<ShoppingCart> _lstGioHang = GetCart();
            ViewBag.TongTien = GetSum();
            ViewBag.TongSoLuong = GetQuantity();
            return PartialView(_lstGioHang);
        }

        public double GetSum()
        {
            double _sum = 0;
            List<ShoppingCart> _lstGioHang = Session[Constants.CART_SESSION] as List<ShoppingCart>;
            if (_lstGioHang != null)
            {
                _sum = _lstGioHang.Sum(x => x.Total);
            }
            return _sum;
        }

        public int GetQuantity()
        {
            List<ShoppingCart> _lstGioHang = Session[Constants.CART_SESSION] as List<ShoppingCart>;
            return _lstGioHang == null ? 0 : _lstGioHang.Sum(x => x.Quantity);
        }
    }
}