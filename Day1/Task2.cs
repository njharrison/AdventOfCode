﻿using AdventOfCode.Tasks;
using System.Linq;

namespace AdventOfCode.Day1
{
    class Task2 : ITask
    {
        public uint Solve(string[] input)
        {
            var actualArray = input.Select(a => uint.Parse(a));

            foreach (var item1 in actualArray)
            {
                foreach (var item2 in actualArray)
                {
                    foreach (var item3 in actualArray)
                    {
                        if (item1 + item2 + item3 == 2020)
                        {
                            return item1 * item2 * item3;
                        }
                    }
                }
            }

            throw new System.ArgumentException("Argument must contain two integers that sum to 2020");
        }
    }
}
