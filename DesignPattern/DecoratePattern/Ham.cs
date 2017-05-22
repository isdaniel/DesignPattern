using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratePattern
{
    public class Ham : IngredientBase
    {
        private IngredientBase _ingredient;

        public Ham(IngredientBase ingredient) {
            _ingredient = ingredient;
        }

        public override string GetName()
        {
            return _ingredient.GetName();
        }

        public override string GetDescription()
        {
            return _ingredient.GetDescription()+ ",精華火腿";
        }

        public override int GetPrice()
        {
            return _ingredient.GetPrice() + 50;
        }
    }
}
