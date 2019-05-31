using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern
{
    public abstract class BagBase
    {
        protected ColorBase color{ get; set; }

        public BagBase(ColorBase color) {
            this.color = color;
        }
        public abstract void GetBag();
    }
}
