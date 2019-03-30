using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern
{
    public class PlugAdapter: IPlugin
    {
        private KoreaPlugin _plugin;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="plugin"></param>
        public PlugAdapter(KoreaPlugin plugin) {
            _plugin = plugin;
        }

        public int Power()
        {
           return _plugin.Power()-110;
        }
    }
}
