namespace StatePattern
{
    public abstract class PaymentStatusBase
    {
        protected PaymentGate _gate;
        public abstract string Running(Product p);

        public abstract string SetStatus(PayStatus s);
    }
}