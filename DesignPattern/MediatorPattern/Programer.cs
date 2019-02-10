using System;

namespace MediatorPattern
{
    public class Programer : OriginReqBase
    {

        public void DoProcess(string message)
        {
            Console.WriteLine($"Programer: {message}");
        }

        public Programer(ProductManager productManager) : base(productManager)
        {
        }
    }
}