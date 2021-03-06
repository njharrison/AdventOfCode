﻿using AdventOfCode.Tasks;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Day03
{
    class Task2 : ITask
    {
        public string Solve(string[] input)
        {
            var treeCounter = new TreeCounter();

            return (treeCounter.CountTrees(input, 1, 1)
                 * treeCounter.CountTrees(input, 3, 1)
                 * treeCounter.CountTrees(input, 5, 1)
                 * treeCounter.CountTrees(input, 7, 1)
                 * treeCounter.CountTrees(input, 1, 2)).ToString();
        }
    }
}
