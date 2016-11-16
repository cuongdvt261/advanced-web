using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AdvancedWeb.Models.DataModel;
using AdvancedWeb.Models.Helper;

namespace AdvancedWeb.Models.DAO
{
    public class CartDAO
    {
        private DataReference db = new DataReference();

        private static CartDAO _instance;

        public static CartDAO Instance
        {
            get
            {
                if (_instance == null) _instance = new CartDAO();
                return _instance;
            }
        }
    }
}