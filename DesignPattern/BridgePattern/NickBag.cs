using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern
{
    public class NickBag : BagBase
    {
        public NickBag(ColorBase color) : base(color)
        {
        }

        public override void GetBag()
        {
            Console.WriteLine($"It is nick Bag,Color is {color.Color()}");
        }
    }
}
