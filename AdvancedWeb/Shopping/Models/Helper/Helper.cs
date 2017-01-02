using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shopping.Models.Helper
{
    public class Helper
    {
        private static Helper _instance;

        public static Helper Instance
        {
            get
            {
                if (_instance == null) _instance = new Helper();
                return _instance;
            }
        }

        public Helper() { }
    }
}