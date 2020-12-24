using AdventOfCode.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day24
{
    class Task1 : Day24TaskBase, ITask
    {
        public string Solve(string[] input)
        {
            var endState = base.GetState(input);

            return endState.Count(a => a.Value).ToString() + " out of " + endState.Count;
        }
    }
}
