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
            Child c = new Child();
            var group = ActionListenerGroup.GetActionListeners();
            //c.AddActionListener(new Father());
            //c.AddActionListener(new Mother());
            c.AddActionListener(group);
            c.weakup();

            Console.ReadKey();
        }
    }

    public class ActionListenerGroup
    {
        const string ASSEMBLYNAME = "ObserverPattern";
        private static string _listeners = ConfigurationManager.AppSettings["Listeners"];

        public static IList<IActionListener> GetActionListeners()
        {
            List<IActionListener> list = new List<IActionListener>();
            string[] listeners = _listeners.Split(',');
            foreach (var listener in listeners)
            {
                string className = ASSEMBLYNAME + "." + listener;
                var obj = Assembly.Load(ASSEMBLYNAME).CreateInstance(className) as IActionListener;

                if (obj != null)
                {
                    list.Add(obj);
                }
            }
            return list;

        }
    }
}
