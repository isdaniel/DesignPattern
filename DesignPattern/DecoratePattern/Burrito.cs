using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratePattern
{
    public class Burrito : IngredientBase
    {
        private string _name;

        public Burrito(string name) {
            _name = name;
        }
  
        public override string GetName()
        {
            return _name;
        }

        public override string GetDescription()
        {
            return "墨西哥餅皮";
        }

        public override int GetPrice()
        {
            return 50;
        }
    }
}
