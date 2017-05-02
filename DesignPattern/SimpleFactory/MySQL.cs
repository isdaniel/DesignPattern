using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFactory
{
    public class MySQL:IDbConcrete
    {
        public void GetDBConcrete()
        {
            Console.WriteLine("執行MYSQL");
        }
    }
}
