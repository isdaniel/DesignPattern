using System;

namespace MediatorPattern
{
    public class DBAdmin : OriginReqBase
    {

        public void DoProcess(string message)
        {
            Console.WriteLine($"DBA:{message}");
        }

        public DBAdmin(ProductManager productManager) : base(productManager)
        {
        }
    }
}