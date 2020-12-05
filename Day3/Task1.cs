﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Day3
{
    class Task1
    {
        public uint Solve(string[] input)
        {
            var treeCounter = new TreeCounter();

            return treeCounter.CountTrees(input, 3, 1);
        }
    }
}
