namespace StatePattern
{
    public class SuccessStatus : PaymentStatusBase
    {
        public SuccessStatus(PaymentGate g)
        {
            _gate = g;
        }

        public override string Running(Product p)
        {
            return "交易完成";
        }

        public override string SetStatus(PayStatus s)
        {
            string result = string.Empty;
            if (s == PayStatus.Init)
                result = "訂單成功請勿修改";
            return result;
        }
    }
}