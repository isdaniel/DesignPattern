using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern
{
    public class Plane : IMoveable
    {

        public void run()
        {
            Console.WriteLine("飛機飛飛飛~~");
        }
    }
}
