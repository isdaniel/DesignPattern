using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern
{
    public class PlaneFactory: IFactory
    {
       public IMoveable create() => new Plane();
    }
}
