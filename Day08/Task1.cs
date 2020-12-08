using AdventOfCode.Tasks;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Day08
{
    class Task1 : Day08TaskBase, ITask
    {
        public long Solve(string[] input)
        {
            var instructionList = ParseInstructions(input);
            return ExecuteProgram(instructionList).Item1;
        }


    }
}
