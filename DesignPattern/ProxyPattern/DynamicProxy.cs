using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern
{
    /// <summary>
    /// 動態代理 動態產生
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DynamicProxy<T> : RealProxy where T : class
    {
        private T _instacne;
        public DynamicProxy(T instance):base(typeof(T))
        {
            _instacne = instance;
        }

        public override IMessage Invoke(IMessage msg)
        {
            var methodCall = msg as IMethodCallMessage;
            var methodBase = methodCall.MethodBase as MethodInfo;
            DoingBefore();
            methodBase.Invoke(_instacne, methodCall.InArgs);
            DoingAfter();
            return new ReturnMessage
                (
                    _instacne,
                    null,
                    0,
                    methodCall.LogicalCallContext,
                    methodCall
                );
        }
        private void DoingBefore()
        {
            Console.WriteLine("DoingBefore Write SomeLog");
        }

        private void DoingAfter()
        {
            Console.WriteLine("DoingAfter Write SomeLog");
        }

    }

}
