using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratePattern
{
    public class Beef : IngredientBase
    {
        private IngredientBase _ingredient;

        public Beef(IngredientBase ingredient) {
            _ingredient = ingredient;
        }

        public override string GetDescription()
        {
            return base.GetDescription()+",牛肉";
        }

        public override string GetName()
        {
            return _ingredient.GetName();
        }

        public override int GetPrice()
        {
            return _ingredient.GetPrice() + 50;
        }
    }
}
