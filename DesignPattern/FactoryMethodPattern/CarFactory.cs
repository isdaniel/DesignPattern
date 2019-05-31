using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern
{
    public class CarFactory: IFactory
    {
       public IMoveable create() => new Car();
    }
}
