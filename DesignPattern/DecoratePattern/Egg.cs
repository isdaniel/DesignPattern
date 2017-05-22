using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratePattern
{
    public class Egg : IngredientBase
    {
        private IngredientBase _ingredient;

        public Egg(IngredientBase ingredient) {
            _ingredient = ingredient;
        }

        public override string GetName()
        {
            return _ingredient.GetName();
        }

        public override string GetDescription()
        {
            return _ingredient.GetDescription() + ",3A級生雞蛋";
        }

        public override int GetPrice()
        {
            return _ingredient.GetPrice() + 10;
        }
    }
}
