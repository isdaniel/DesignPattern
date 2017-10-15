using ProxyPattern;
using ProxyPattern.DynamicProxy;
using ProxyPattern.StaticProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            #region StaticProxy

            var testUser = new UserModel() { Password = "1234", RowID = 1, UserName = "test" };
            LogicProxyService staticProxy = new LogicProxyService(new Logicservice());
            staticProxy.IsAuth(testUser);

            #endregion StaticProxy

            #region DynamicProxy

            //產生代理類別
            var proxy = new DynamicProxy<DLogicservice>(new DLogicservice());
            //取得代理類別實體
            var obj = proxy.GetTransparentProxy() as DLogicservice;
            //呼叫方法
            obj.IsAuth(testUser);

            #endregion DynamicProxy

            Console.ReadKey();
        }
    }
}