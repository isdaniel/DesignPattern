using Microsoft.VisualStudio.TestTools.UnitTesting;
using StatePattern;

namespace StatePatternTests.Normal
{
    [TestClass()]
    public class PaymentGateTests
    {
        [TestMethod()]
        public void Normal_Item()
        {
            Product p = new Product() { Name = "蘋果", Price = 30 };
            PaymentGate context = new PaymentGate(p);

            Assert.AreEqual("交易建立中...", context.RunProcess());
            Assert.AreEqual("交易中請稍後", context.RunProcess());
            Assert.AreEqual("交易完成", context.RunProcess());
        }

        [TestMethod()]
        public void Normal_OverPriceItem()
        {
            Product p = new Product() { Name = "蘋果", Price = 5555 };
            PaymentGate context = new PaymentGate(p);

            Assert.AreEqual("交易建立中...", context.RunProcess());
            Assert.AreEqual("物件超過300元 交易取消中", context.RunProcess());
            Assert.AreEqual("交易取消完成", context.RunProcess());
        }

        [TestMethod()]
        public void SetProcess_Cancel_AlterDontResetAgain()
        {
            Product p = new Product() { Name = "蘋果", Price = 3000 };
            PaymentGate context = new PaymentGate(p);

            Assert.AreEqual("請勿重新建立訂單", context.SetStatus(PayStatus.Init));
            Assert.AreEqual("交易建立中...", context.RunProcess());
            Assert.AreEqual("請勿重新建立訂單", context.SetStatus(PayStatus.Init));
            Assert.AreEqual("物件超過300元 交易取消中", context.RunProcess());
            Assert.AreEqual("交易取消完成", context.RunProcess());
            Assert.AreEqual("訂單取消請勿修改", context.SetStatus(PayStatus.Init));
        }

        [TestMethod()]
        public void SetProcess_Success_AlterDontResetAgain()
        {
            Product p = new Product() { Name = "蘋果", Price = 30 };
            PaymentGate context = new PaymentGate(p);

            Assert.AreEqual("請勿重新建立訂單", context.SetStatus(PayStatus.Init));
            Assert.AreEqual("交易建立中...", context.RunProcess());
            Assert.AreEqual("請勿重新建立訂單", context.SetStatus(PayStatus.Init));
            Assert.AreEqual("交易中請稍後", context.RunProcess());
            Assert.AreEqual("交易完成", context.RunProcess());
            Assert.AreEqual("訂單成功請勿修改", context.SetStatus(PayStatus.Init));
        }
    }
}