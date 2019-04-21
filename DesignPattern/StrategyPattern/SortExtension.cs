using System;
using System.Collections.Generic;
using System.Linq;

namespace StrategyPattern
{
    public static class SortExtension
    {
        public static IEnumerable<T> SortBy<T>(this T[] list, ICompareStrategy<T> compare)
        {
            if (list == null || compare == null)
                throw new ArgumentException("list can't be null");
            
            for (int i = 1; i < list.Count(); i++)
            {
                for (int j = i; j < list.Count(); j++)
                {
                    if (compare.Compare(list[i - 1], list[j]) > 0)
                    {
                        T temp = list[j];
                        list[j] = list[i - 1];
                        list[i - 1] = temp;
                    }
                }
            }

            return list;
        }
    }
}