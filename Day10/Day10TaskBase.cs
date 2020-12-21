using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day10
{
    abstract internal class Day10TaskBase
    {
        protected List<int> PopulateAdapterList(string[] input)
        {
            var adapterArray = input.Select(a => int.Parse(a)).OrderBy(a => a).ToList();
            adapterArray.Insert(0, 0);
            adapterArray.Add(adapterArray.Max() + 3);
            return adapterArray;
        }
    }
}