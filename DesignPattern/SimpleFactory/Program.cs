using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            IDbConcrete dataConner = ConnectionFactory.GetConnection(DBType.MySQL);
            dataConner.GetDBConcrete();
            Console.ReadKey();
        }
    }
}
