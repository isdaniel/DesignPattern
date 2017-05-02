using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OracleClient;
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
