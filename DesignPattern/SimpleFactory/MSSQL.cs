using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFactory
{
    public class MSSQL : IDbConcrete
    {
        public void GetDBConcrete()
        {
            Console.WriteLine("執行MYSQL");
        }
    }
}
