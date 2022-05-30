// See https://aka.ms/new-console-template for more information
public interface IStateCommnad{
    void Execute(Product product);
    ProductState CurrentState { get; } 

    HashSet<ProductState> AllowState {get;}
}
// See https://aka.ms/new-console-template for more information

public interface IStateCommnadHandler{
    void Execute(IStateCommnad command,Product product);
}

// public class StateCommnadHandler : IStateCommnadHandler
// {
//     public void Execute(IStateCommnad command)
//     {
//         if (command.AllowState.Contains(product.State))
//         {
//             System.Console.WriteLine($"將 {product.Name} => {CurrentState} 更新狀態到 {product.State}");
//         }
//         else {
//             throw new Exception($"Not Allow Action CurrentState:{CurrentState} try to {product.State}");
//         }     

//         command.Execute(product);
//     }
// }

public class NewState : IStateCommnad
{
    public ProductState CurrentState { get; } = ProductState.New;

    public HashSet<ProductState> AllowState {get;}= new HashSet<ProductState>(){
        ProductState.New
    };
    public void Execute(Product product)
    {
        if (AllowState.Contains(product.State))
        {
            System.Console.WriteLine($"將 {product.Name} => 新增物件 狀態：{CurrentState} ");
        }
        else {
            throw new Exception($"Not Allow Action CurrentState:{product.State} try to {CurrentState}");
        }       
    }
}

public class CancelState : IStateCommnad
{
    public ProductState CurrentState { get; } = ProductState.Cancel;

    public HashSet<ProductState> AllowState {get;} = new HashSet<ProductState>(){
        ProductState.New,
        ProductState.Processing
    };
    public void Execute(Product product)
    {
        if (AllowState.Contains(product.State))
        {
            System.Console.WriteLine($"將 {product.Name} => {product.State} 更新狀態到 {CurrentState}");
            product.State = CurrentState;
        }
        else {
            throw new Exception($"Not Allow Action CurrentState:{product.State} try to {CurrentState}");
        }       
    }
}

public class ProcessingState : IStateCommnad
{
    public ProductState CurrentState { get; } = ProductState.Processing;

    public HashSet<ProductState> AllowState {get;} = new HashSet<ProductState>(){
        ProductState.New
    };
    public void Execute(Product product)
    {
        if (AllowState.Contains(product.State))
        {
            System.Console.WriteLine($"將 {product.Name} => {product.State} 更新狀態到 {CurrentState}");
            product.State = CurrentState;
        }
        else {
            throw new Exception($"Not Allow Action CurrentState:{product.State} try to {CurrentState}");
        }       
    }
}



public class DeliverState : IStateCommnad
{
    public ProductState CurrentState { get; } = ProductState.Deliver;

    public HashSet<ProductState> AllowState {get;} = new HashSet<ProductState>(){
        ProductState.Processing
    };
    public void Execute(Product product)
    {
        if (AllowState.Contains(product.State))
        {
            System.Console.WriteLine($"將 {product.Name} => {product.State} 更新狀態到 {CurrentState}");
            product.State = CurrentState;
        }
        else {
            throw new Exception($"Not Allow Action CurrentState:{product.State} try to {CurrentState}");
        }       
    }
}
