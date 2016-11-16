using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AdvancedWeb.Models.DataModel;

namespace AdvancedWeb.Models.DAO
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

        private DataReference db = new DataReference();

        public List<Product> GetProductToList()
        {
            return db.Products.ToList();
        }

        public List<Product> GetProductByCatIdToList(int catId)
        {
            return db.Products.Where(p => p.CategoryId == catId).ToList();
        }

        public List<Product> GetProductByCatIdTakeCountToList(int catId, int count)
        {
            return db.Products.Where(p => p.CategoryId == catId).Take(count).ToList();
        }

        public List<Product> GetProductByCatIdOrderToList(int CatId, int sortOrder)
        {
            var product = from p in db.Products
                          select p;
            switch (sortOrder)
            {
                case 1:
                    product = db.Products.Where(x => x.CategoryId == CatId).OrderByDescending(x => x.Name);
                    break;
                case 2:
                    product = db.Products.Where(x => x.CategoryId == CatId).OrderBy(x => x.Price);
                    break;
                default:
                    break;
            }
            return product.ToList();
        }

        public List<Product> GetNewManProduct()
        {
            return db.Products.Where(x => x.CategoryId == 1).OrderByDescending(x => x.Id).Take(6).ToList();
        }

        public List<Product> GetNewWomanProduct()
        {
            return db.Products.Where(x => x.CategoryId == 2).OrderByDescending(x => x.Id).Take(6).ToList();
        }
    }
}