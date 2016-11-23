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

        public List<Product> GetProductNotDelete(int CatId)
        {
            return db.Products.Where(x => x.CategoryId == CatId && x.Deleted == false).ToList();
        }

        public List<Product> GetProductToList()
        {
            return db.Products.ToList();
        }

        public List<Product> GetProductByCatIdToList(int catId)
        {
            return GetProductNotDelete(catId);
        }

        public List<Product> GetProductByCatIdTakeCountToList(int catId, int count)
        {
            return GetProductNotDelete(catId).Take(count).ToList();
        }

        public List<Product> GetProductByCatIdOrderToList(int CatId, int sortOrder)
        {
            List<Product> lstProduct = new List<Product>();
            switch (sortOrder)
            {
                case 1:
                    lstProduct = GetProductNotDelete(CatId).OrderByDescending(x => x.Name).ToList();
                    break;
                case 2:
                    lstProduct = GetProductNotDelete(CatId).OrderByDescending(x => x.Price).ToList();
                    break;
                case 3:
                    lstProduct = GetProductNotDelete(CatId).OrderBy(x => x.Name).ToList();
                    break;
                case 4:
                    lstProduct = GetProductNotDelete(CatId).OrderBy(x => x.Price).ToList();
                    break;
                default:
                    break;
            }
            return lstProduct;
        }

        public List<Product> GetNewManProduct()
        {
            return GetProductNotDelete(1).OrderByDescending(x => x.Id).Take(6).ToList();
        }

        public List<Product> GetNewWomanProduct()
        {
            return GetProductNotDelete(2).OrderByDescending(x => x.Id).Take(6).ToList();
        }

        public List<Product> GetProductByCatIdFilterPrice(int CatId, double minPrice, double maxPrice)
        {
            return GetProductNotDelete(CatId).Where(x => x.Price <= maxPrice && x.Price >= minPrice).ToList();
        }
    }
}