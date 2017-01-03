using Shopping.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shopping.Areas.Admin.Models.DAO
{
    public class AdminRoleDAO
    {
        private static AdminRoleDAO _instance;

        public static AdminRoleDAO Instance
        {
            get
            {
                if (_instance == null) _instance = new AdminRoleDAO();
                return _instance;
            }
        }

        private DataShop db;

        public AdminRoleDAO()
        {
            db = new DataShop();
        }

        public List<int> GetRoleByUserGroup(int userId)
        {
            var user = db.Users.Find(userId);
            if (user != null)
            {
                var data = (from p in db.UserGroupRoles
                            join ug in db.UserGroups on p.UserGroupId equals ug.Id
                            join r in db.Roles on p.RoleId equals r.Id
                            where ug.Id == user.UserGroupId
                            select new
                            {
                                RoleId = p.RoleId
                            });
                return data.Select(x => x.RoleId).ToList();
            }
            else
            {
                return null;
            }
        }

        public List<int> GetRoleByUser(int userId)
        {
            var data = (from ur in db.UserRoles
                        join r in db.Roles on ur.RoleId equals r.Id
                        where ur.UserId == userId
                        select new
                        {
                            RoleId = ur.RoleId
                        });
            return data.Select(x => x.RoleId).ToList();
        }

        public List<int> GetAllRoleByUser(int userId)
        {
            return AdminRoleDAO.Instance.GetRoleByUser(userId)
                .Union(AdminRoleDAO.Instance.GetRoleByUserGroup(userId))
                .ToList();
        }

        public List<String> GetListRoleName(List<int> roleIds)
        {
            List<String> roleNames = new List<String>();
            if (roleIds != null)
            {
                foreach (var roleId in roleIds)
                {
                    var role = db.Roles.Find(roleId);
                    roleNames.Add(role.Name);
                }
            }
            return roleNames;
        }

        public List<Role> GetAllRole()
        {
            return db.Roles.ToList();
        }

        public void SetRoleByUser(int userId, int roleId)
        {
            UserRole ur = new UserRole()
            {
                UserId = userId,
                RoleId = roleId,
            };
            db.UserRoles.Add(ur);
            db.SaveChanges();
        }

        public void RemoveRoleByUser(int userId, int roleId)
        {
            UserRole urole = db.UserRoles.Find(roleId, userId);
            db.UserRoles.Remove(urole);
            db.SaveChanges();
        }

        public void SetRoleByUserGroup(int uGroupId, int roleId)
        {
            UserGroupRole ur = new UserGroupRole()
            {
                UserGroupId = uGroupId,
                RoleId = roleId,
            };
            db.UserGroupRoles.Add(ur);
            db.SaveChanges();
        }

        public void RemoveRoleByUserGroup(int uGroupId, int roleId)
        {
            UserGroupRole data = db.UserGroupRoles.Find(uGroupId, roleId);
            db.UserGroupRoles.Remove(data);
            db.SaveChanges();
        }

        public String SetRole(String rName, String rDescription)
        {
            var result = db.Roles.SingleOrDefault(x => x.Name == rName && x.Description == rDescription);
            if (result != null)
            {
                return "Đã tồn tại !";
            }
            else
            {
                Role role = new Role()
                {
                    Name = rName,
                    Description = rDescription
                };
                db.Roles.Add(role);
                db.SaveChanges();
                return "Success";
            }
        }
    }
}