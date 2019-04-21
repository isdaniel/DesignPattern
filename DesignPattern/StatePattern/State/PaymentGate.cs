namespace StatePattern
{
    public class PaymentGate
    {
        private readonly Product _product;

        internal PaymentStatusBase CurrentProcess { get; set; }

        public PaymentGate(Product p)
        {
            _product = p;
            CurrentProcess = new InitStatus(this);
        }

        internal PayStatus CurrentStatus { get; set; }

        /// <summary>
        /// 設置狀態
        /// </summary>
        /// <param name="status"></param>
        public string SetStatus(PayStatus status)
        {
            return CurrentProcess.SetStatus(status);
        }

        /// <summary>
        /// 跑流程
        /// </summary>
        /// <returns></returns>
        public string RunProcess()
        {
            return CurrentProcess.Running(_product);
        }
    }
}
