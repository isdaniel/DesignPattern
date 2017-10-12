using ProxyPattern;
using ProxyPattern.StaticProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern
{
    class Program
    {
        static void Main(string[] args)
        {

            #region StaticProxy
            var testUser = new UserModel() { Password = "1234", RowID = 1, UserName = "test" };
            LogicProxyService staticProxy = new LogicProxyService(new Logicservice());
            staticProxy.IsAuth(testUser); 
            #endregion

            Console.ReadKey();
        }
    }
}
