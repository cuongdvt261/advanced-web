using Shopping.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shopping.Areas.Admin.Models.DAO
{
    public class AdminPermissionDAO
    {
        private static AdminPermissionDAO _instance;
        private DataShop db;

        public static AdminPermissionDAO Instance
        {
            get
            {
                if (_instance == null) _instance = new AdminPermissionDAO();
                return _instance;
            }
        }

        public AdminPermissionDAO()
        {
            db = new DataShop();
        }

        public List<Role> GetListRole()
        {
            return db.Roles.ToList();
        }
    }
}