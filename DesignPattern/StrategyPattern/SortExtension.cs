using System;
using System.Collections.Generic;
using System.Linq;
using StrategyPattern.Strategy;

namespace StrategyPattern
{
    public static class SortExtension
    {
        public static Person[] SortByStrategy<T>(this Person[] list)
        {
            if (list == null)
                throw new ArgumentException("list can't be null");

            for (int i = 1; i < list.Count(); i++)
            {
                for (int j = i; j < list.Count(); j++)
                {
                    //這邊需要寫死比較方式
                    if (list[i - 1].Age > list[j].Age)
                    {
                        Swap(list, j, i);
                    }
                }
            }

            return list;
        }


        public static T[] SortByStrategy<T>(this T[] list, ICompareStrategy<T> compare)
        {
            if (list == null || compare == null)
                throw new ArgumentException("list can't be null");
            
            for (int i = 1; i < list.Count(); i++)
            {
                for (int j = i; j < list.Count(); j++)
                {
                    //自訂一個規則介面,比較方式由外部提供 由外部注入!!
                    if (compare.Compare(list[i - 1], list[j]) > 0)
                    {
                        Swap(list, j, i);
                    }
                }
            }

            return list;
        }

        private static void Swap<T>(T[] list, int j, int i)
        {
            T temp = list[j];
            list[j] = list[i - 1];
            list[i - 1] = temp;
        }
    }
}