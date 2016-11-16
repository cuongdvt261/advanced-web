using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AdvancedWeb.Models.DataModel;

namespace AdvancedWeb.Models.DAO
{
    public class CatagoryDAO
    {
        private static CatagoryDAO _instance;

        public static CatagoryDAO Instance
        {
            get
            {
                if (_instance == null) _instance = new CatagoryDAO();
                return _instance;
            }
        }

        private DataReference db = new DataReference();

        public List<Category> GetCatagoryToList()
        {
            return db.Categories.ToList();
        }
    }
}