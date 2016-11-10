using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdvancedWeb.Models
{
    public class FakeData
    {
        public int MenuId { get; set; }
        public String MenuTitle { get; set; }
        public int ParentId { get; set; }

        public FakeData()
        {

        }

        public FakeData(int menuId, String menuTitle, int parentId)
        {
            this.MenuId = menuId;
            this.MenuTitle = menuTitle;
            this.ParentId = parentId;
        }
    }
}