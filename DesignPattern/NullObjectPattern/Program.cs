using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NullObjectPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            CartModel model = null;
            Console.WriteLine(Calculate(model));
            Console.ReadKey();
        }

        static decimal Calculate(CartModel model)
        {
            var paymentService = model == null
                ? (IPaymentService)
                new NullPayment()
                : new PaymentService();
            return paymentService.calculate(model);
        }
    }
}
