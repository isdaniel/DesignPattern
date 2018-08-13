using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern.DynamicProxy
{
    public class DLogicservice : MarshalByRefObject
    {
        private MockUserData userList = new MockUserData();

        [Log]
        public bool IsAuth(UserModel user)
        {
            Console.WriteLine("IsAuth");
            return userList.GetAllUser()
                 .Any(o => user.UserName == o.UserName && user.Password == o.Password);
        }
    }
}