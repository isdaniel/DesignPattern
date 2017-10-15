using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern.DynamicProxy
{
    public class DynamicProxy<T> : RealProxy
        where T : MarshalByRefObject
    {
        private MarshalByRefObject _target;

        public DynamicProxy(T target) : base(typeof(T))
        {
            _target = target;
        }

        /// <summary>
        /// 動態攔截方法實作的瞬間
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public override IMessage Invoke(IMessage msg)
        {
            IMethodCallMessage callMethod = msg as IMethodCallMessage;
            MethodInfo targetMethod = callMethod.MethodBase as MethodInfo;
            IMethodReturnMessage returnMethod = null;
            //得到方法上面的標籤 攔截要執行非核心邏輯的動作
            var attrs = Attribute.GetCustomAttributes(targetMethod, typeof(AopBaseAttribute)) as AopBaseAttribute[];
            try
            {
                foreach (var attr in attrs)
                {
                    //執行方法前的動作
                    attr.Excuting(callMethod.Args);
                }
                //執行方法
                var result = targetMethod.Invoke(_target, callMethod.Args);
                returnMethod = new ReturnMessage(result,
                                      callMethod.Args,
                                      callMethod.Args.Length,
                                      callMethod.LogicalCallContext,
                                      callMethod);
                foreach (var attr in attrs)
                {
                    //執行方法後動作
                    attr.Excuted(result);
                }
            }
            catch (Exception ex)
            {
                returnMethod = new ReturnMessage(ex, callMethod);
            }
            return returnMethod;
        }
    }
}