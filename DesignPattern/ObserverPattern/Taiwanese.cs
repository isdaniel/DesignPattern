using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ObserverPattern
{ 
    public class Taiwanese : IObservea
    {
        private Youtuber _youtuber;
        public Taiwanese(Youtuber youtuber)
        {
            _youtuber = youtuber;
        }

        public void Update(string message)
        { 
            Console.WriteLine($"{this.GetType().Name}收到訊息:{message}");
        }
    }
}
