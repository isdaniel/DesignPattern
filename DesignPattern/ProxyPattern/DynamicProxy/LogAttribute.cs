using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern.DynamicProxy
{
    public class LogAttribute : AopBaseAttribute
    {
        public override void Excuting(object[] args)
        {
            var user = args.FirstOrDefault() as UserModel;
            if (user != null)
            {
                Console.WriteLine($"DynamicProxy 使用者登入：帳號={user.UserName} 密碼={user.Password}");
            }
            Console.WriteLine();
        }
    }

    public abstract class AopBaseAttribute : Attribute, IInterception
    {
        public virtual void Excuted(object result)
        {
        }

        public virtual void Excuting(object[] args)
        {
        }
    }
}