using Microsoft.VisualStudio.TestTools.UnitTesting;
using StrategyPattern;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StrategyPattern.Strategy;

namespace StrategyPattern.Tests
{
    [TestClass()]
    public class ComparePersonTests
    {
        [TestMethod()]
        public void CompareTest()
        {
            var p1 = new Person() {Age = 10, Name = "Daniel"};
            var p2 = new Person() { Age = 1, Name = "Daniel1" };

            IEnumerable<Person> persons = new List<Person>()
            {
                p1,
                p2
            };

            ICollection expect = new List<Person>() {p2, p1};

            ICollection act = persons.ToArray()
                                     .SortByStrategy(new ComparePerson()).ToList();

            CollectionAssert.AreEqual(expect, act);
        }
    }
}