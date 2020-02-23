# Null Object Pattern

## 前言:

假如在系統中`null`散佈在有許多地方且`null`有相對應的邏輯或行為.這時候就很適合使用`NullObject Pattern`來解決，已Null Object取代`null`邏輯.

## Null可能引申出來問題

我們知道在.Net或Java中大部分都是參考類型,而null是參考類型的預設值，我們來看看以下程式.

```csharp
Person p = null;
Console.WriteLine(p.Age);
```

如果物件`p`指向`null`且取得`p.Age`時就會`throw NullReferenceException`，所以我們在使用一些參考類型物件前都會先判斷此物件是否為null，在執行後續邏輯.

在系統中某一兩個地方這樣判斷還好，但如果一直重複這樣的判斷會造成程式碼不必要的膨脹....

相較於「不帶有null邏輯」的程式碼，面對null邏輯往往需要花費更多心力.

## 範例程式

下面有段程式碼在`calculate`方法中會判斷`CartModel`物件是否為null並執行相對應邏輯

```csharp
public class PaymentServiceNormal
{
    public decimal calculate(CartModel model)
    {
        decimal result = 0m;
        if (model == null)
            return result;

        result = model.Items.Sum(x => x.Price);

        if (result > 400m)
            result *= 0.8m;

        return result;
    }
}
```

我們可以將`calculate`方法提取出一個介面並對於null部份提取成一個類別實現此介面

能看到`NullPayment`這個類別已經被賦予相對應動作操作.

```csharp
public interface IPaymentService
{
    decimal calculate(CartModel model);
}

public class PaymentService : IPaymentService
{
    public decimal calculate(CartModel model)
    {
        decimal result = model.Items.Sum(x => x.Price);

        if (result > 400m)
            result *= 0.8m;

        return result;
    }
}

public class NullPayment : IPaymentService
{
    public decimal calculate(CartModel model)
    {
        return 0m;
    }
}
```

在使用時我們就可統一判斷是否為null來給予相對應物件

> 這邊有點像是策略者模式(`Strategy pattern`)，判斷要使用哪個邏輯，邏輯統一封裝到類別中.

```csharp
class Program
{
    static void Main(string[] args)
    {
        CartModel model = null;
        Console.WriteLine(Calculate(model));
        Console.ReadKey();
    }

    static decimal Calculate(CartModel model)
    {
        var paymentService = model == null
            ? (IPaymentService)
            new NullPayment()
            : new PaymentService();
        return paymentService.calculate(model);
    }
}
```

## NullObject Pattern缺點:

如果團隊工程師不知道目前程式碼已經存在NullObject實作，會寫出多餘的null測試.
如果目前系統只是需要少量對於null做判斷，這時導入NullObject會導致程式碼變得複雜.

## 小結:

假如系統中有許多地方需要判斷null並處理相對應的動作就很適合使用`NullObject` Pattern，但如果判斷null地方不是很多還是判斷就好了

[程式碼範例](https://github.com/isdaniel/DesignPattern/tree/master/DesignPattern/NullObjectPattern)