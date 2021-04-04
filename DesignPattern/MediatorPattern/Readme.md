# MediatorPattern(中介者模式)

系統模塊存在很多複雜的耦合問題，很適合使用中介者模式來解耦合

## 說明

在現實中如果組織有一定規模可能構通如下圖那般複

![Alt text](https://dotblogsfile.blob.core.windows.net/user/%E4%B9%9D%E6%A1%83/f718d961-2f8b-46ac-a2f7-b95af802f23a/1549790323_53498.png "Optional title")


如果有一個人或組織負責幫大家協助溝通，就可解決上面複雜問題

![Alt text](https://dotblogsfile.blob.core.windows.net/user/%E4%B9%9D%E6%A1%83/f718d961-2f8b-46ac-a2f7-b95af802f23a/1549790493_52417.png "Optional title")


這就是我們這次的核心中介者

-----

## 中介者模式有幾個角色

* AbstractMediator (抽像中介者)：定義中介者和各個同事者之間的通信的介面
* ConcreteMediator (中介者)：知道每個同事物件，實現抽像中介者，負責協調和各個具體的同事的交互關係
* AbstractColleague (抽象同事者)：定義同事者和中介者通信的接口
* ConcreteColleague (同事者)：實現自己的業務，並且實現抽象方法，跟中介者進行通信
中介者模式特點是

中介者知道所有同事者物件，但同事者互相不知道對方存在需透過中介者傳遞訊息
如何傳遞和通知各個同事者由中介者內部決定
在裡面第二點是很重要的目標，把傳遞訊息的邏輯封裝在中介者裡面

程式碼

    public class ProductManager
    {
        public DBAdmin DbAdmin { get; set; }
        public Programer Programer { get; set; }

        internal void Send(string message, OriginReqBase req)
        {
    　　　　　　 //如果是DBAdmin傳遞訊息由Programer執行,反之
                if (req.GetType() == typeof(DBAdmin))
                    Programer.DoProcess(message);
                else if(req.GetType() == typeof(Programer))
                    DbAdmin.DoProcess(message);
        }
    }

 傳遞通知或訊息邏輯寫在`Send` 方法裡面.

本次範例依照傳入的型別,如果是`DBAdmin`傳遞訊息由`Programer`執行,反之

    public abstract class OriginReqBase
    {
        protected ProductManager _productManager;

        protected OriginReqBase(ProductManager productManager)
        {
            _productManager = productManager;
        }

        public virtual void Requirement(string message)
        {
            _productManager.Send(message, this);
        }
    }

`OriginReqBase`(抽象同事者) 因為每個角色 `ConcreteColleague` 都需要知道中介者存在，所以把參數設定在建構子上。

`Requirement` 方法通知 `PM` 中介者將資料傳遞出去

    public class Programer : OriginReqBase
    {

        public void DoProcess(string message)
        {
            Console.WriteLine($"Programer: {message}");
        }

        public Programer(ProductManager productManager) : base(productManager)
        {
        }
    }

    public class DBAdmin : OriginReqBase
    {

        public void DoProcess(string message)
        {
            Console.WriteLine($"DBA:{message}");
        }

        public DBAdmin(ProductManager productManager) : base(productManager)
        {
        }
    }
    DoProcess 方法 PM 中介者呼叫使用

    ProductManager pm = new ProductManager();

    DBAdmin DBA1 = new DBAdmin(pm);　//DBA知道PM存在
    Programer RD1 = new Programer(pm);　//RD知道PM存在

    pm.Programer = RD1; //PM知道DBA
    pm.DbAdmin = DBA1;  //PM知道RD

//現在DBA和RD只需要傳訊息就可將訊息轉到需要知道的人

    RD1.Requirement("DB modify Requestment.");
    DBA1.Requirement("DB Process doing.");

有三大重點

1. `DBA`和`RD`(同事者) 知道`PM`(中介者)存在
2. `PM`(中介者)知道`DBA`和`RD`(同事者)存在
3. `DBA`和`RD`不用知道對方存在但卻可以互相傳遞訊息(因為PM已經幫助我們解耦合了)

![Alt text](https://az787680.vo.msecnd.net/user/%E4%B9%9D%E6%A1%83/f718d961-2f8b-46ac-a2f7-b95af802f23a/1549792143_37531.png "Optional title")

> UML圖 (有標示相對應的角色關係)

我看來這個解耦合核心思想跟容器有點像，因為需要做溝通或通知時我們統一只需要轉交給中介者會幫助我們處理溝通事宜
