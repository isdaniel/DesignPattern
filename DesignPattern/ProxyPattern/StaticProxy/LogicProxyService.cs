using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern.StaticProxy
{
    public class LogicProxyService : ISubject
    {
        private ISubject _realSubjcet;
        public LogicProxyService(ISubject sub)
        {
            _realSubjcet = sub;
        }

        public bool IsAuth(UserModel user)
        {
            Console.WriteLine($"使用者登入：帳號={user.UserName} 密碼={user.Password}");
            return _realSubjcet.IsAuth(user);
        }
    }
}
