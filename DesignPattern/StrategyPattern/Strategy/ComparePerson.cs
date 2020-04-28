namespace StrategyPattern.Strategy
{
    public class ComparePerson : ICompareStrategy<Person>
    {
        public int Compare(Person obj1, Person obj2)
        {
            if (obj1.Age > obj2.Age)
                return 1;

            return -1;
        }
    }
}