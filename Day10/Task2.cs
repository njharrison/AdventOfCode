using AdventOfCode.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day10
{
    class Task2 : Day10TaskBase, ITask
    {
        public ulong Solve(string[] input)
        {
            var adapterList = PopulateAdapterList(input);

            var jumpOptions = new Dictionary<int, ulong>
            {
                { adapterList.Max(), 1 }
            };
            for (var i = adapterList.Count - 2; i >= 0; i--)
            {
                var jumpableSpots = adapterList.Where(a => a > adapterList[i] && a <= adapterList[i] + 3);
                ulong options = 0;
                foreach (var joltage in jumpableSpots)
                {
                    if (jumpOptions.ContainsKey(joltage))
                    {
                        options += jumpOptions[joltage];
                    }
                }
                jumpOptions.Add(adapterList[i], options);
            }

            return jumpOptions[0];
        }
    }
}
