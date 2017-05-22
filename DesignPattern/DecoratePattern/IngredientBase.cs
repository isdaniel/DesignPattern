using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratePattern
{
    public abstract class IngredientBase
    {
        private string name = "空";

        private string description = "空";

        public abstract int GetPrice();

        public virtual string GetName()
        {
            return this.name;
        }

        public virtual string GetDescription()
        {
            return this.description;
        }
    }
}
