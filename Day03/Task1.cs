using AdventOfCode.Tasks;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Day03
{
    class Task1 : ITask
    {
        public string Solve(string[] input)
        {
            var treeCounter = new TreeCounter();

            return treeCounter.CountTrees(input, 3, 1).ToString();
        }
    }
}
