using Shopping.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shopping.Models.DAO
{
    public class CategoryDAO
    {
        private static CategoryDAO _instance;
        public static CategoryDAO Instance
        {
            get
            {
                if (_instance == null) _instance = new CategoryDAO();
                return _instance;
            }
        }

        private DataShop db;

        public CategoryDAO()
        {
            db = new DataShop();
        }

        public List<Category> GetListCategory()
        {
            return db.Categories.ToList();
        }
    }
}