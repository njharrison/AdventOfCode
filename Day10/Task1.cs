using AdventOfCode.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day10
{
    class Task1 : Day10TaskBase, ITask
    {
        public string Solve(string[] input)
        {
            List<int> adapterArray = PopulateAdapterList(input);

            var differenceArray = new List<int>();
            for (var i = 0; i < adapterArray.Count - 1; i++)
            {
                differenceArray.Add(adapterArray[i + 1] - adapterArray[i]);
            }
            return (differenceArray.Where(a => a == 3).Count() * differenceArray.Where(a => a == 1).Count()).ToString();
        }
    }
}
