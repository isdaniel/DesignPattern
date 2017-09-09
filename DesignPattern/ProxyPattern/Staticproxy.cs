using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern
{
  
    public class LogProxy : ISubject
    {
        private ISubject _proxyInstance;
        public LogProxy()
        {
            _proxyInstance = new RealSubject();
        }

        public void Work()
        {
            DoingBefore();
            _proxyInstance.Work();
            DoingAfter();
        }


        private void DoingBefore()
        {
            Console.WriteLine("DoingBefore Write SomeLog");
        }

        private void DoingAfter()
        {
            Console.WriteLine("DoingAfter Write SomeLog");
        }
    }

}
