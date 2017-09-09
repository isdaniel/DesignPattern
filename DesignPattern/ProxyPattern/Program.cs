using ProxyPattern;
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
            ISubject proxy = new LogProxy();
            proxy.Work();
            #endregion

            #region DynamicProxy
            ProxyFactroy<ISubject> proxyObj = new ProxyFactroy<ISubject>(typeof(RealSubject), null);
            proxyObj.GetInstace().Work(); 
            #endregion

            Console.ReadKey();
        }
    }
}
