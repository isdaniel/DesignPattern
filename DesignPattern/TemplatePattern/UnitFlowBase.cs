using System;
using System.Collections.Generic;

namespace TemplatePattern
{
    public abstract class UnitFlowBase
    {
        protected virtual void OneTimeSetUp()
        {
        }

        protected virtual void Dispose()
        {
        }

        protected virtual void SetUp()
        {
        }

        protected virtual void TearDown()
        {
        }

        public void UnitTest(IEnumerable<Func<bool>> testCases)
        {
            OneTimeSetUp();
            foreach (var testCase in testCases)
            {
                SetUp();
                Console.WriteLine(testCase() ? "Assert Successful." : "Assert Fail.");
                TearDown();
            }
            Dispose();
        }
    }
}