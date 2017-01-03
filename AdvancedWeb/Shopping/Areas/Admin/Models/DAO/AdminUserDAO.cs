using Shopping.Areas.Admin.Models.Helper;
using Shopping.Models.DataModel;
using Shopping.Models.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shopping.Areas.Admin.Models.DAO
{
    [Author]
    public class AdminUserDAO
    {
        private static AdminUserDAO _instance;

        public static AdminUserDAO Instance
        {
            get
            {
                if (_instance == null) _instance = new AdminUserDAO();
                return _instance;
            }
        }

        private DataShop db;

        public AdminUserDAO()
        {
            db = new DataShop();
        }

        public String GetUserGroupById(int? Id)
        {
            UserGroup uGroup = db.UserGroups.Find(Id);
            return uGroup != null ? uGroup.Name : "";
        }

        public List<UserGroup> GetAllUserGroup()
        {
            return db.UserGroups.ToList();
        }

        public bool isLogin(String username, String password)
        {
            String hashPass = DataHelper.Instance.MD5Hash(password);
            var user = db.Users.SingleOrDefault(u => u.Username == username && u.Password == hashPass);
            return user != null ? true : false;
        }

        public int GetUserIdByUsername(String username)
        {
            var user = db.Users.SingleOrDefault(u => u.Username == username);
            return user != null ? user.Id : -1;
        }
    }
}