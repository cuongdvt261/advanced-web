using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Shopping.Models.Helper
{
    public class DataHelper
    {
        private static DataHelper _instance;

        public static DataHelper Instance
        {
            get
            {
                if (_instance == null) _instance = new DataHelper();
                return _instance;
            }
        }

        public DataHelper() { }

        public String MD5Hash(string text)
        {
            MD5 _md5 = new MD5CryptoServiceProvider();

            //compute hash from the byte of text
            _md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            //get hash result after compute it
            byte[] _result = _md5.Hash;

            StringBuilder _strBuilder = new StringBuilder();
            for (int i = 0; i < _result.Length; i++)
            {
                //change it into 2 hexadecimal digits
                //for each byte
                _strBuilder.Append(_result[i].ToString("x2"));
            }
            return _strBuilder.ToString();
        }
    }
}