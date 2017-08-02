using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern
{
    /// <summary>
    /// 真正要執行的類別
    /// </summary>
    public class RealSubject : ISubject
    {
        public void Work()
        {
            Console.WriteLine("It is RealSubject");
        }
    }
}
