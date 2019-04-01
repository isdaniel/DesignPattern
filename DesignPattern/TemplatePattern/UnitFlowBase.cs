using System;

namespace TemplatePattern
{
    public abstract class UnitFlowBase
    {
        protected UnitFlowBase()
        {
            SetUpClass();
        }

        protected virtual void SetUpClass()
        {
        }

        protected virtual void SetUpUnitTest()
        {
        }

        protected abstract bool Execute();

        public void UnitTest()
        {
            SetUpUnitTest();
            Console.WriteLine(Execute() ? "Assert Successful." : "Assert Fail.");
        }
    }
}