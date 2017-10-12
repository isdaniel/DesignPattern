using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern.StaticProxy
{
    public class Logicservice : ISubject
    {
        MockUserData userList = new MockUserData();

        public bool IsAuth(UserModel user)
        {
            return userList.GetAllUser()
                 .Any(o => user.UserName == o.UserName && user.Password == o.Password);
        }
    }
}
