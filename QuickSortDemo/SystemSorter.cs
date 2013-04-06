using System;
using System.Collections.Generic;
using System.Linq;

namespace QuickSortDemo
{
    public class SystemSorter<T>: ISorter<T>
        where T : IComparable<T>
    {
        public void Sort(IList<T> data)
        {
            var sortedList = data.OrderBy(_ => _).ToList();
            int i = 0;
            foreach (var element in sortedList)
            {
                data[i++] = element;
            }
        }
    }
}