using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MediatorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager pm = new ProductManager();

            DBAdmin DBA1 = new DBAdmin(pm);　//DBA知道PM存在
            Programer RD1 = new Programer(pm);　//RD知道PM存在

            pm.Programer = RD1; //PM知道DBA
            pm.DbAdmin = DBA1;  //PM知道RD

            //現在DBA和RD只需要傳訊息就可將訊息轉到需要知道的人
            RD1.Requirement("DB modify Requirement.");
            DBA1.Requirement("DB Process doing.");

            Console.ReadKey();
        }
    }
}
