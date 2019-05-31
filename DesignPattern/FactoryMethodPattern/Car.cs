using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern
{
    public class Car : IMoveable
    {
        public void run()
        {
            Console.WriteLine("車車跑跑跑~~");
        }
    }
}
