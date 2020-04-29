using System;

namespace TemplatePattern
{
    public class UnitCounter : UnitFlowBase
    {
        protected override void SetUp()
        {
            Console.WriteLine("Set up UnitCounter thing.");
        }

        protected override void OneTimeSetUp()
        {
            Console.WriteLine("OneTimeSetUp!!");
        }
    }
}