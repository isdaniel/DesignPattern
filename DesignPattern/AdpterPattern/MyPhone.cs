using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern
{
    public class MyPhone
    {
        /// <summary>
        /// 對手機充電
        /// </summary>
        public void Fill_Cellphone(int power) {
            if (power==110)
            {
                Console.WriteLine("充電成功");
            }
            else
            {
                Console.WriteLine("電壓太高!手機爆炸!");
            }            
        }
    }
}
