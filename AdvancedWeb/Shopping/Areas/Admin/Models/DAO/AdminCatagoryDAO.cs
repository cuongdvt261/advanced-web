using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Shopping.Models.DataModel;

namespace Shopping.Areas.Admin.Models.DAO
{
    public class AdminCatagoryDAO
    {
        private DataShop db = new DataShop();

        private static AdminCatagoryDAO _instance;
        public static AdminCatagoryDAO Instance
        {
            get
            {
                if (_instance == null) _instance = new AdminCatagoryDAO();
                return _instance;
            }
        }

        public String GetCatNameByCatId(int Id)
        {
            Category cat = db.Categories.Find(Id);
            return cat != null ? cat.Name : "";
        }

        public List<String> GetAllCatName()
        {
            return db.Categories.Select(x => x.Name).ToList();
        }
    }
}