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
            unitCounter.UnitTest(new List<Func<bool>>()
            {
                ()=>true,
                ()=>false,
                ()=>false,
                ()=>true
            });

            Console.ReadKey();
        }
    }
}
