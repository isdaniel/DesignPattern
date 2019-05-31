using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern
{
    public class Warships : IFireable
    {
        public void Fire()
        {
            Console.WriteLine("Warships Fire");
        }
    }
}
