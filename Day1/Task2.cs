using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day1
{
    class Task2
    {
        public int Solve(string[] input)
        {
            var actualArray = input.Select(a => int.Parse(a));

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
