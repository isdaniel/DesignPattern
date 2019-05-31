using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            AdidasBag nick = new AdidasBag(new ColorBlue());
            nick.GetBag();
            Console.ReadKey();
        }
    }
}
