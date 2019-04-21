# 代理模式(ProxyPattern)

前言：

1. [什麼是代理模式,為什麼要用他](#什麼是代理模式,為什麼要用他)
2. [利用.NET實現靜態代理](#利用.NET實現靜態代理)
3. [利用.NET實現動態代理](#利用.NET實現動態代理)

----

## 什麼是代理模式,為什麼要用他

大家在寫程式時一定常常遇到要寫日誌，權限驗證....等等和主要邏輯不相干的事情

如果把上述這些動作寫在核心邏輯，會讓原有的程式碼變得雜亂

AOP(面向切面编程)可以有效的幫助我們解決上面問題，降低模塊間耦合度，理念來自於代理模式...

Asp dot net MVC的`ActionFilterAttribute`就是Aop一個很好的例子

只要在Action上加一個自己做的Filter 就可在方法執行前後做事情，且不更動原來程式碼

因為不改動原有程式碼，可以降低Bug的發生機會，很經典的實現了OCP(開放封閉原則)

我會用已現實生活中常常遇到的 **[登入系統]** 來跟大家介紹代理模式的奧妙

----

## 初版程式碼

假如我們要寫一個登入程式，在第一版時我們將他的核心邏輯寫完［檢查使用者是否合法］

```c#
/// <summary>
/// 檢查用戶是否合法
/// </summary>
/// <returns></returns>
public bool IsUserAuth(UserModel user)
{
    return userList.GetAllUser()
        .Any(o => user.UserName == o.UserName && user.Password == o.Password);
}
```

> 如果沒使用動態代理會怎麼來寫Log呢?

```c#
/// <summary>
/// 檢查用戶是否合法
/// </summary>
/// <returns></returns>
public bool IsUserAuth(UserModel user)
{
    Console.WriteLine($"使用者登入：帳號={user.UserName} 密碼={user.Password}");
    return userList.GetAllUser()
        .Any(o => user.UserName == o.UserName && user.Password == o.Password);
}
```

（已Console.WriteLine來代替寫log的程式碼)
在執行前後寫上Log，但這樣讓程式碼可讀性變差了點，因為Log和檢查使用者是否登入完全沒關係!

那我們要怎麼做才可讓程式碼Clear一點呢?
在下面我會介紹靜態代理模式，來解決上面的問題

----

## 利用.NET實現靜態代理

我們先理解業務在哪邊，業務在下面紅框的部分 `Console.log` 只是記錄此次驗證的資料

> 我們可以主要邏輯提取動作來做一個簽章

![img](https://az787680.vo.msecnd.net/user/%E4%B9%9D%E6%A1%83/17bcea05-79ca-46d6-8893-d1c4ae124d4f/1507791353_49889.png)

> 在我心中**介面代表能力，抽象類別代表這一類事物**

因為在此次需求驗證是一種能力，所以我提出來成一個介面

```c#
public interface ISubject
{
    bool IsAuth(UserModel user);
}
```

有兩個類別 `LogicProxyService`和`Logicservice`都實現 `ISubject`
因為不管是代理類別和被代理類別都擁有檢核能力

我們就可將主要邏輯寫在`Logicservice `

```c#
public class Logicservice : ISubject
{
    MockUserData userList = new MockUserData();

    public bool IsAuth(UserModel user)
    {
        return userList.GetAllUser()
                .Any(o => user.UserName == o.UserName && user.Password == o.Password);
    }
}
```

這邊我使用依賴注入的建構子注入，讓外界決定要注入哪個類別（需繼承ISubject）
可增加未來擴展性和移植性
 撰寫日誌寫在 `LogicProxyService`

```c#
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
```

在外界只需這樣使用

傳入被代理物件
使用代理物件呼叫方法

```c#
#region StaticProxy
var testUser = new UserModel() { Password = "1234", RowID = 1, UserName = "test" };
LogicProxyService staticProxy = new LogicProxyService(new Logicservice());
staticProxy.IsAuth(testUser);
#endregion
```

這樣程式碼就比上一篇乾淨許多了！ 寫日誌的程式碼和主要邏輯分離開來

靜態代理最主要是將核心邏輯和非核心邏輯分割開來，讓程式碼保持乾淨


但靜態代理還是有個缺點，如我們需要擴充100個代理方法 我需要撰寫100代理類別

實在有夠累....

但別擔心在下面會介紹**[動態代理模式]**來解決此問題

----

## 利用.NET實現動態代理

靜態代理可以將執行邏輯和寫日誌這兩個動作分離乾淨

Q：但又衍生一個問題是我們有一大堆代理類別要寫，這樣好不方便

A：如果可以攔截或獲取方法實行的瞬間並在執行前後加上我們寫日誌的動作該有多好

聰明的.Net框架 已經幫我們處理上面問題了(不然我們要動態產生一堆程式碼和動態編譯他們...這會累屎人QQ)

> 何謂動態代理?

簡單來說就是

> 這個代理類別在Runtime期間由程式動態幫我們生產

我簡單來使用 [.Net RealProxy](https://docs.microsoft.com/zh-tw/dotnet/api/system.runtime.remoting.proxies.realproxy?redirectedfrom=MSDN&view=netframework-4.7.2) 類別來實作，[透明動態代理]

要被RealProxy代理類別要符合以下一種情況

1. 介面
2. 繼承於`MarshalByRefObject`

廢話不多說先附上程式碼 

```c#
public class DynamicProxy<T> : RealProxy
    where T : MarshalByRefObject
{
    private MarshalByRefObject _target;

    public DynamicProxy(T target) : base(typeof(T))
    {
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
```

這是動態代理最核心的程式碼

繼承`RealProxy`類別並實作`IMessage`方法

```c#
public override IMessage Invoke(IMessage msg)
```

我們把上篇的靜態代理改成動態代理

首先我們為動態代理新增攔截點製作 `AopBaseAttribute`
 為日後切面擴展程式的基礎

```c#
public abstract class AopBaseAttribute : Attribute, IInterception
{
    public virtual void Excuted(object result)
    {
    }

    public virtual void Excuting(object[] args)
    {
    }
}
```

新增`LogAttribute` 作為寫日誌的切入點

```c#
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
```

邏輯類別那邊繼承 `MarshalByRefObject` 並將剛剛做的 Log標籤(`Attirbute`) 放在方法上

```c#
public class DLogicservice : MarshalByRefObject
{
    private MockUserData userList = new MockUserData();

    [Log]
    public bool IsAuth(UserModel user)
    {
        return userList.GetAllUser()
                .Any(o => user.UserName == o.UserName && user.Password == o.Password);
    }
}
```

調用時只需要這樣

```c#
//產生代理類別
var proxy = new DynamicProxy<DLogicservice>(new DLogicservice());
//取得代理類別實體
var obj = proxy.GetTransparentProxy() as DLogicservice;
//呼叫方法
obj.IsAuth(testUser);
```

另外小弟有參考ASP.Net原始碼來製作動態的攔截器框架 [AwesomeProxy.Net](https://github.com/isdaniel/AwesomeProxy.Net) ，放在github上面歡迎大家討論