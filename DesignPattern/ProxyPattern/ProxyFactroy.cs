using ProxyPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern
{
    public class ProxyFactroy<T> where T : class
    {
        private DynamicProxy<T> _proxy;
        public ProxyFactroy(Type instance,object[] args)
        {
            var obj = Activator.CreateInstance(instance, args) as T;
            _proxy = new DynamicProxy<T>(obj);
        }

        public T GetInstace()
        {
            return _proxy.GetTransparentProxy() as T;
        }

    }
}
