using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern
{
    public class AdidasBag : BagBase
    {
        public AdidasBag(ColorBase color) : base(color)
        {
        }

        public override void GetBag()
        {
            Console.WriteLine($"It is Adidas Bag,Color is {color.Color()}");
        }
    }
}
