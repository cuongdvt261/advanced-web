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
    }
}