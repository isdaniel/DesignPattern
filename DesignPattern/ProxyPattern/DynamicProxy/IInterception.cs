using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern.DynamicProxy
{
    public interface IInterception
    {
        void Excuted(object result);

        void Excuting(object[] args);
    }
}