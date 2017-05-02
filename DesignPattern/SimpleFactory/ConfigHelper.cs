using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFactory
{
    public class ConfigHelper
    {
        private static string _strConn = "";
        public static string StrConn {
            get {
                if (string.IsNullOrEmpty(_strConn))
                {
                    _strConn = ConfigurationManager.AppSettings["MyConnstr"].ToString();
                }
                return _strConn;
            }
        }
    }
}
