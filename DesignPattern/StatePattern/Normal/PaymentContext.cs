namespace StatePattern.Normal
{


    public class PaymentContext
    {
        Product _Item { get; set; }

        PayStatus _status { get; set; }

        public PaymentContext(Product p)
        {
            _Item = p;
            _status = PayStatus.Init;
        }

        /// <summary>
        /// 設置狀態
        /// </summary>
        /// <param name="status"></param>
        public string SetStatus(PayStatus status) {
            string result = $"修改成功{status.ToString()}";
            switch (_status)
            {
                case PayStatus.Init:
                    if (status == PayStatus.Init)
                        result = "請勿重新建立訂單";
                    else
                        _status = status;
                    break;
                case PayStatus.Success:
                    result = "訂單成功請勿修改";
                    break;
                case PayStatus.Cancel:
                    result = "訂單取消請勿修改";
                    break;
                case PayStatus.Processing:
                    if (status == PayStatus.Init)
                        result = "請勿重新建立訂單";
                    else
                        _status = status;
                    break;
            }


            return result;
        }

        /// <summary>
        /// 跑流程
        /// </summary>
        /// <returns></returns>
        public string RunProcess() {

            switch (_status)
            {
                case PayStatus.Init:
                    _status = PayStatus.Processing;
                    return "交易建立中...";
                case PayStatus.Success:
                    return "交易完成";
                case PayStatus.Cancel:
                    return "交易取消完成";
                case PayStatus.Processing:
                    if (_Item.Price > 300)
                    {
                        _status = PayStatus.Cancel;
                        return "物件超過300元 交易取消中";
                    }
                    _status = PayStatus.Success;
                    return "交易中請稍後";
            }
            return "不在狀態內";        
        }
    }
}
