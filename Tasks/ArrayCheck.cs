using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Tasks
{
    class ArrayCheck
    {
        internal static Tuple<ulong, ulong> FindTwoValuesWithSum(IEnumerable<ulong> items, ulong value)
        {
            foreach (var item1 in items)
            {
                foreach (var item2 in items)
                {
                    if (item1 + item2 == value)
                    {
                        return new Tuple<ulong, ulong>(item1, item2);
                    }
                }
            }

            return null;
        }
    }
}
