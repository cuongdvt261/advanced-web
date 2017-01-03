using Shopping.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shopping.Areas.Admin.Models.DAO
{
    public class AdminProductDAO
    {
        private static AdminProductDAO _instance;

        public static AdminProductDAO Instance
        {
            get
            {
                if (_instance == null) _instance = new AdminProductDAO();
                return _instance;
            }
        }

        private DataShop db;

        public AdminProductDAO()
        {
            db = new Shopping.Models.DataModel.DataShop();
        }

        public List<Product> GetAllListProduct()
        {
            return db.Products.ToList();
        }
    }
}