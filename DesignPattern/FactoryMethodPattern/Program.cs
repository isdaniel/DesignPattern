using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern
{
    class Program
    {
        static void Main(string[] args)
        {

            IFactory factory = new PlaneFactory();
            IMoveable m= factory.create();
            m.run();
            Console.ReadKey();
        }
    }
}
