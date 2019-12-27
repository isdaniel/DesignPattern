using System.Linq;

namespace NullObjectPattern
{
    public class PaymentService : IPaymentService
    {
        public decimal calculate(CartModel model)
        {
            decimal result = model.Items.Sum(x => x.Price);

            if (result > 400m)
                result *= 0.8m;

            return result;
        }
    }

    public interface IPaymentService
    {
        decimal calculate(CartModel model);
    }

    public class NullPayment : IPaymentService
    {
        public decimal calculate(CartModel model)
        {
            return 0m;
        }
    }
}