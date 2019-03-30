## AdpterPattern，轉接器模式

轉接器模式  是一個蠻實用的設計範式

舉例：

前一陣子出國去韓國玩，有去韓國的朋友都知道他們的插座和台灣的插座不一樣 而且電壓是220V，到這我也是矇了

![Alt text](https://az787680.vo.msecnd.net/user/%E4%B9%9D%E6%A1%83/fdbe4057-b2bd-40a8-8e62-150b8bac4f35/1492506304_59516.jpg "Optional title")

(圖片來源:網路截圖)

所幸導遊有給我們插頭的轉接器，讓我們用可以幫我解決

![Alt text](https://az787680.vo.msecnd.net/user/%E4%B9%9D%E6%A1%83/fdbe4057-b2bd-40a8-8e62-150b8bac4f35/1492506352_49069.jpg "Optional title")

(圖片來源:網路截圖)

1. 電壓220V->110V
2. 形狀可以符合台灣一般的插頭

> 為什麼會舉這個例子呢？

因為轉接器模式和我剛剛舉的例子有異曲同工之妙

-----

例子來寫個簡單的小程式：

首先我們先創建一個類別`KoreaPlugin`(韓國插座)

裡面有個方法:

Power供電220V

```C#
public class KoreaPlugin
{
    public int Power(){
    return 220;
    }
}
```

在創建一個類我的手機:

他只能承受110V的電壓

超過就爆炸了!!

```C#
public class MyPhone
{
    /// <summary>
    /// 對手機充電
    /// </summary>
    public void Fill_Cellphone(int power) {
        if (power==110)
        {
            Console.WriteLine("充電成功");
        }
        else
        {
            Console.WriteLine("電壓太高!手機爆炸!");
        }
    }
}
```

如果要充電怎麼辦?

這時我們的轉接頭發揮功用了

創建一個轉接頭的類別:

```C#
public class PlugAdapter: IPlugin
{
    private KoreaPlugin _plugin;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="plugin"></param>
    public PlugAdapter(KoreaPlugin plugin) 
    {
        _plugin = plugin;
    }

    public int Power()
    {
        return _plugin.Power()-110;
    }
}
```

在上面可以看到它 內部幫我們做了電壓轉換 (重要注意!!)

所以我們就可以進行充電了

```c#
static void Main(string[] args)
{
    #region 手機爆炸
    KoreaPlugin p = new KoreaPlugin();
    int power = p.Power();
    MyPhone phone = new MyPhone();
    phone.Fill_Cellphone(power);
    #endregion;

    #region 正常充電
    IPlugin adapter = new PlugAdapter(new KoreaPlugin());
    int power_safe = adapter.Power();
    phone.Fill_Cellphone(power_safe);
    #endregion;

    Console.ReadKey();
}
```

現實生活中轉接器幫我解決

可用110V充電
用台灣一般的插頭充電
而內部實現機制我們不用理只管用就好

就像上面的範例:

`PlugAdapter`在內部幫我們進行電壓轉換封裝，而我們可以直接用就好

`AdapterPattern`使用時機：

有一或多個類別或介面，不符合我們的需求

但不能在裡面直接改內部方法或實現方式

那我們可以使用`AdapterPattern`來當我們的轉換器

轉成我適合我們使用介面或接口

-----

## 實戰範例：

需求要讀取資料，所以我們有一個類別`FileReader`

裡面有一個`Read`方法來讀取硬碟資料

```c#
public class FileReader
{
    public string Read(string parameter)
    {
        string result = string.Empty;
        //實作硬碟讀取
        return result;
    }
}
```

日後需求增加可能從網路,資料庫其他來源讀取我們要的資料，所以我們開出一個 **Interface** 可以搭配[工廠模式](https://github.com/isdaniel/DesignPattern/tree/master/DesignPattern/SimpleFactory) 來掌控我們的產品

```c#
public interface IReadData
{
    string GetJsonData(string parameter);
}
```

新增的`WebReader`可以繼承此介面

```c#
/// <summary>
/// 從網路上讀取要的資料
/// </summary>
public class WebReader : IReadData
{
    public string GetJsonData(string parameter)
    {
        string result = string.Empty;
        //實作網路讀取
        return result;
    }
}
```

但如果想讓舊有的`FileReader`也共享此介面怎麼處理呢?

這時可以考慮使用`Adapter` 來做銜接處理

```c#
public class FileAdapter : IReadData
{
    public string GetJsonData(string parameter)
    {
        var reader = new FileReader();
        return reader.Read(parameter);
    }
}
```

建立一個`FileAdapter`並實現`IReadData`裡的方法，我們可以看到裡面我們一樣是使用`FileReader`，但外部的看到的介面已經不一樣了.

我們就可以讓`WebReader`和`FileAdapter` 達成相同介面.


