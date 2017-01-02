using Shopping.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shopping.Models.DAO
{
    public class UserDAO
    {
        private static UserDAO _instance;
        public static UserDAO Instance
        {
            get
            {
                if (_instance == null) _instance = new UserDAO();
                return _instance;
            }
        }

        private DataShop db;

        public UserDAO() { db = new DataShop(); }

        public bool isLogin(String username, String password)
        {
            var user = db.Users.SingleOrDefault(u => u.Username == username && u.Password == password);
            return user != null ? true : false;
        }

        public String GetUsernameById(int Id)
        {
            return db.Users.Find(Id).Name;
        }
    }
}