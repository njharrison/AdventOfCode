﻿using AdventOfCode.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day15
{
    class Task2 : Day15TaskBase, ITask
    {
        public string Solve(string[] input)
        {
            return this.Solve(input, 30000000).ToString();
        }
    }
}
