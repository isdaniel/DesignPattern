namespace MediatorPattern
{
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
}