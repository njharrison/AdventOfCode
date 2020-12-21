using AdventOfCode.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day19
{
    class Task2 : Day20TaskBase, ITask
    {
        public ulong Solve(string[] input)
        {
            return 0;

#pragma warning disable CS0162 // Unreachable code detected - disabled because of performance
            for (var i = 0; i < input.Length; i++)
#pragma warning restore CS0162 // Unreachable code detected
            {
                var line = input[i];
                if (line.StartsWith("8:"))
                {
                    input[i] = "8: 42 | 42 8";
                }
                if (line.StartsWith("11:"))
                {
                    input[i] = "11: 42 31 | 42 11 31";
                }
            }

            return base.SolveForInput(input);
        }
    }
}
