﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace AdvancedWeb.Models.Helper
{
    public class UserHelper
    {
        private static UserHelper _instance;
        public static UserHelper Instance
        {
            get
            {
                if (_instance == null) _instance = new UserHelper();
                return _instance;
            }
        }

        public String MD5Hash(String _text)
        {
            MD5 _md5 = new MD5CryptoServiceProvider();

            //compute hash from the byte of text
            _md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(_text));

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