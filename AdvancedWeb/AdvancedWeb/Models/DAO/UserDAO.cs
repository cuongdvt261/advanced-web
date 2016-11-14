using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AdvancedWeb.Models.DataModel;

namespace AdvancedWeb.Models.DAO
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

        private DataReference db = new DataReference();

        public bool CheckLogin(String uname, String upass)
        {
            var result = db.Users.SingleOrDefault(user => user.Username == uname && user.Password == upass);
            return (result != null) ? true : false;
        }

        public void Register(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }
    }
}