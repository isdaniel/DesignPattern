using System;

namespace TemplatePattern
{
    public class UnitCounter : UnitFlowBase
    {
        private int _classCounter = 0;

        private int _methodCounter = 0;

        protected override void SetUpClass()
        {
            _classCounter++;
        }

        protected override void SetUpUnitTest()
        {
            _methodCounter++;
        }

        protected override bool Execute()
        {
            Console.WriteLine($"ClassCounter : {_classCounter}");
            Console.WriteLine($"MethodCounter: { _methodCounter}");

            return true;
        }
    }
}