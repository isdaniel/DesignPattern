using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Reflection;

namespace ObserverPattern
{
    class Program
    {
        static void Main(string[] args)
        {

            Youtuber youtuber = new Youtuber();
            youtuber.AddsubScription(new Taiwanese(youtuber));

            youtuber.Notify("頻道開啟");

            Console.ReadKey();
        }
    }
}
