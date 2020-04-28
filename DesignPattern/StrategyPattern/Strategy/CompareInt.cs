namespace StrategyPattern.Strategy
{
    public class CompareInt : ICompareStrategy<int>
    {
        public int Compare(int obj1, int obj2)
        {
            if (obj1 > obj2)
                return 1;
            
            return -1;
        }
    }
}