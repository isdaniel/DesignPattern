using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullObjectPattern
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.ReadKey();
        }
    }

    

    public class PaymentServiceNormal
    {
        public decimal calculate(CartModel model)
        {
            decimal result = 0m;
            if (model == null)
                return result;

            result = model.Items.Sum(x => x.Price);

            if (result > 400m)
                result *= 0.8m;

            return result;
        }
    }
}
