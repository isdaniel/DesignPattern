using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern
{
    public class UserModel
    {
        public long RowID { get; set; }
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
