using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern.StaticProxy
{
    public interface ISubject
    {
        bool IsAuth(UserModel user);
    }
}
