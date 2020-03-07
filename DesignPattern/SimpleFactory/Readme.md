Simple Factory,Factory,簡單工廠模式

今天和大家介紹另一個常用且簡單的模式

在.net中`MSSQL`和`MYSQL` 都是連接資料庫 但只是插在連接使用的類別不一樣

那我們要怎麼封裝到一個類上呢?

這時候可以使用工廠模式

UML圖:

![Alt text](https://raw.githubusercontent.com/isdaniel/DesignPattern/master/DesignPattern/img/simpleFactory/simpleFatory.png)

定義一個 介面`IDbConcrete` 裡面提供 連接資料庫之動作

    public interface IDbConcrete
    {
        void GetDBConcrete();
    }

分別定義`MSSQL，MYSQL，ORACLE` 三個連接資料庫 並實現 IDbConcrete實作 連接方式

    public class MSSQL : IDbConcrete
    {
        public void GetDBConcrete()
        {
            Console.WriteLine("執行MYSQL");
        }
    }


    public class MySQL:IDbConcrete
    {
        public void GetDBConcrete()
        {
            Console.WriteLine("執行MYSQL");
        }
    }


    public class Oracle : IDbConcrete
    {
        public void GetDBConcrete()
        {
            Console.WriteLine("執行Oracle");
        }
    }

最重要工廠實體類 ConnectionFactory

    public class ConnectionFactory
    {
        public static IDbConcrete GetConnection(DBType type) {
            IDbConcrete db = null;
            switch (type)
            {
                case DBType.MySQL:
                    db=new MySQL();
                    break;
                case DBType.MSSQL:
                    db = new MSSQL();
                    break;
                case DBType.Oracle:
                    db = new Oracle();
                    break;
                default:
                    db = new MSSQL();
                    break;
            }
            return db;
        }
    }

我們在外面呼叫就很簡單 給一個參數就會由工廠提供給我們一個相對應的實體

    class Program
    {
        static void Main(string[] args)
        {
            IDbConcrete dataConner = ConnectionFactory.GetConnection(DBType.MySQL);
            dataConner.GetDBConcrete();
            Console.ReadKey();
        }
    }
 

但簡單工廠有個不足的地方，日後有追加實體須在工廠類中的switch新增 ex:新增DB2連接方式
違反開放封閉原則(OCP)