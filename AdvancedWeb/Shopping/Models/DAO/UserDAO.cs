using Shopping.Models.DataModel;
using Shopping.Models.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Shopping.Models.Helper;

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
            String hashPass = DataHelper.Instance.MD5Hash(password);
            var user = db.Users.SingleOrDefault(u => u.Username == username && u.Password == hashPass);
            return user != null;
        }

        public String GetUsernameById(int Id)
        {
            return db.Users.Find(Id).Name;
        }

        public void DoRegister(User user)
        {
            var newUser = db.Users.Create();
            newUser.Name = user.Name;
            newUser.Email = user.Email;
            newUser.Birthday = user.Birthday;
            newUser.Address = user.Address;
            newUser.Password = DataHelper.Instance.MD5Hash(user.Password);
            newUser.Username = user.Username;
            newUser.Deleted = false;
            newUser.UserGroupId = 3;
            newUser.AccessFailedCount = 3;
            newUser.PhoneNumber = user.PhoneNumber;
            db.Users.Add(newUser);
            db.SaveChanges();
        }

        public bool IsEmailExist(String email)
        {
            return db.Users.FirstOrDefault(u => u.Email == email) != null;
        }

        public bool IsUsernameExist(String username)
        {
            return db.Users.FirstOrDefault(u => u.Username == username) != null;
        }
    }
}