using System;
using System.Collections.Generic;

namespace QuickSortDemo
{
    public interface ISorter<T>
        where T : IComparable<T>
    {
        void Sort(IList<T> data);
    }
}