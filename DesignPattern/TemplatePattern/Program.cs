using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TemplatePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            
            UnitCounter unitCounter = new UnitCounter();
            unitCounter.UnitTest();
            unitCounter.UnitTest();
            unitCounter.UnitTest();

            Console.ReadKey();
        }
    }
}
