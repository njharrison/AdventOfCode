using AdventOfCode.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day18
{
    class Task2 : Day18TaskBase, ITask
    {
        public string Solve(string[] input)
        {
            ulong sum = 0;
            var expressionEvaluator = new ExpressionEvaluator();
            foreach (var line in input)
            {
                sum += (ulong)expressionEvaluator.Evaluate(line, true);
            }

            return sum.ToString();
        }
    }
}
