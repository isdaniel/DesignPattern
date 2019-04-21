namespace StatePattern
{
    public class ProcessStatus : PaymentStatusBase
    {
        public ProcessStatus(PaymentGate g)
        {
            _gate = g;
        }
        public override string Running(Product p)
        {
            string result = "交易中請稍後";

            if (p.Price > 300)
            {
                result = "物件超過300元 交易取消中";
                _gate.CurrentProcess = new CancelStatus(_gate);
            }
            else
                _gate.CurrentProcess = new SuccessStatus(_gate);

            return result;
        }

        public override string SetStatus(PayStatus s)
        {
            string result = string.Empty;
            if (s == PayStatus.Init)
                result = "請勿重新建立訂單";
            return result;
        }
    }
}