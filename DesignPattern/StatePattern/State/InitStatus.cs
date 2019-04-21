namespace StatePattern
{
    public class InitStatus : PaymentStatusBase
    {
        
        public InitStatus(PaymentGate g)
        {
            _gate = g;
        }

        public override string Running(Product p)
        {
            _gate.CurrentProcess = new ProcessStatus(_gate);
            return "交易建立中...";
        }

        public override string SetStatus(PayStatus status)
        {
          
            string result = "";
            if (status == PayStatus.Init)
                result = "請勿重新建立訂單";
            else
                _gate.CurrentStatus = status;

            return result;
        }
    }
}