using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern
{
    public class AddidasBag : BagBase
    {
        public AddidasBag(ColorBase color) : base(color)
        {
        }

        public override void GetBag()
        {
            Console.WriteLine($"It is Addidas Bag,Color is {color.Color()}");
        }
    }
}
