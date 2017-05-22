using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            IngredientBase awesomeBurrito = new Burrito("豪華墨西哥捲");
            awesomeBurrito = new Egg(awesomeBurrito);//加蛋
            awesomeBurrito = new Ham(awesomeBurrito);//加火腿
            awesomeBurrito = new Beef(awesomeBurrito);//加火腿
            Console.WriteLine($"商品名稱:{awesomeBurrito.GetName()} \n 價格:{awesomeBurrito.GetPrice()}\n 使用材料:{awesomeBurrito.GetDescription()}");
            Console.ReadKey();
        }
    }
}
