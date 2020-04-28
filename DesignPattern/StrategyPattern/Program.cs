using System;
using System.Text;
using System.Threading.Tasks;
using StrategyPattern.Strategy;

namespace StrategyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new[] {5, 3, 2, 4,1,10};
            foreach (var item in arr.SortByStrategy(new CompareInt()))
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
}
