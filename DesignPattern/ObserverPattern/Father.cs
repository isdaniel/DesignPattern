using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public class Father : IActionListener
    {
        void IActionListener.ExcuteAction()
        {
            Console.WriteLine("爸爸餵飯");
        }
    }
}
