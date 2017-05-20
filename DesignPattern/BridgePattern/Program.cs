using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            NickBag nick = new NickBag(new ColorRed());
            nick.GetBag();
            Console.ReadKey();
        }
    }
}
