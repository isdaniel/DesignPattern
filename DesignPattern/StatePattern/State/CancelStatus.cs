namespace StatePattern
{
    public class CancelStatus : PaymentStatusBase
    {
        public CancelStatus(PaymentGate g)
        {
            _gate = g;
        }
        public override string Running(Product p)
        {
            return "交易取消完成";
        }

        public override string SetStatus(PayStatus s)
        {
            string result = string.Empty;
            if (s == PayStatus.Init)
                result = "訂單取消請勿修改";
            return result;
        }
    }
}