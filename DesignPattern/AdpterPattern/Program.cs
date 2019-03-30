using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 手機爆炸
            KoreaPlugin p = new KoreaPlugin();
            int power = p.Power();
            MyPhone phone = new MyPhone();
            phone.Fill_Cellphone(power);
            #endregion;
            PlugAdapter adapter = new PlugAdapter(new KoreaPlugin());
            int power_safe = adapter.Power();
            phone.Fill_Cellphone(power_safe);

            Console.ReadKey();
        }
    }
}
