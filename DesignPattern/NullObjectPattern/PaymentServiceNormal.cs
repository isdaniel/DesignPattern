using System.Linq;

namespace NullObjectPattern
{

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