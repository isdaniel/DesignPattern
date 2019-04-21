using Microsoft.VisualStudio.TestTools.UnitTesting;
using StrategyPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.Tests
{
    [TestClass()]
    public class CompareIntTests
    {
        [TestMethod()]
        public void CompareTest()
        {
            int[] arrange = new[] { 5, 3, 2, 4, 1, 10 };

            int[] expect = new[] {1, 2, 3, 4, 5, 10};

            int[] act = arrange.SortBy(new CompareInt()).ToArray();

            CollectionAssert.AreEqual(expect, act);
        }

        [TestMethod()]
        public void CompareTest1()
        {
            int[] arrange = new[] {1,2,3,4,5 };

            int[] expect = new[] { 1, 2, 3, 4, 5 };

            int[] act = arrange.SortBy(new CompareInt()).ToArray();

            CollectionAssert.AreEqual(expect, act);
        }
    }
}