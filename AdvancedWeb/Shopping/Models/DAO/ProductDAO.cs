using Shopping.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shopping.Models.DAO
{
    public class ProductDAO
    {
        private static ProductDAO _instance;

        public static ProductDAO Instance
        {
            get
            {
                if (_instance == null) _instance = new ProductDAO();
                return _instance;
            }
        }

        private DataShop db;

        public ProductDAO()
        {
            db = new DataShop();
        }

        public List<Product> GetListProduct()
        {
            return db.Products.ToList();
        }

        public List<Product> GetListNotDeleteProduct()
        {
            return db.Products.Where(p => p.Deleted == false).ToList();
        }

        public List<Product> GetListTakeNumberNotDeleteProduct(int number)
        {
            return GetListNotDeleteProduct().Take(number).ToList();
        }

        public List<Product> GetListProductByCatId(int CatId)
        {
            return GetListNotDeleteProduct().Where(p => p.CategoryId == CatId).ToList();
        }

        public List<Product> FilterProductByPrice(int minPrice, int maxPrice, int catId)
        {
            return GetListNotDeleteProduct().Where(p => p.CategoryId == catId && p.Price < maxPrice && p.Price >= minPrice).ToList();
        }
    }
}