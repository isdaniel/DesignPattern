using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace SimpleFactory
{
    public class Oracle : IDbConcrete
    {
        public void GetDBConcrete()
        {
            Console.WriteLine("執行Oracle");
        }
    }
}
