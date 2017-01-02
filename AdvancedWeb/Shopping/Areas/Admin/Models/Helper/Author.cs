using Shopping.Areas.Admin.Models.DAO;
using Shopping.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shopping.Areas.Admin.Models.Helper
{
    public class Author : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            AdminRoleDAO r = new AdminRoleDAO();
            int currentUserId = int.Parse(HttpContext.Current.Session["AdminLogin"].ToString());
            List<String> roleNames = AdminRoleDAO.Instance.GetListRoleName(AdminRoleDAO.Instance.GetAllRoleByUser(currentUserId));
            String actionName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName + "-" +
                filterContext.ActionDescriptor.ActionName;
            if (!roleNames.Contains(actionName))
            {
                filterContext.Result = new RedirectResult("~/Admin/Home/Warning");
            }
        }
    }
}