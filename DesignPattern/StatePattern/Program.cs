using StatePattern.Normal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    public class Product {
        public decimal Price { get; set; }

        public string Name { get; set;   }

    }
 
    public enum PayStatus {
        Init,
        Success,
        Cancel,
        Processing
    }

    class Program
    {
        static void Main(string[] args)
        {
            Product p = new Product();
            p.Name = "電腦";
            p.Price = 300000;

            PaymentGate context = new PaymentGate(p);
            Console.WriteLine(context.RunProcess());
            Console.WriteLine(context.RunProcess());
            Console.WriteLine(context.RunProcess());
            context.SetStatus(PayStatus.Init);
            Console.WriteLine(context.RunProcess());
            Console.ReadKey();
        }
    }
}
