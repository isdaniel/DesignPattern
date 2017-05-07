using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public class Mother : IActionListener
    {
        void IActionListener.ExcuteAction()
        {
            Console.WriteLine("媽媽帶小孩看電視");
        }
    }
}
