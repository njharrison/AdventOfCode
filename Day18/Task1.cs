using AdventOfCode.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day18
{
    class Task1 : Day18TaskBase, ITask
    {
        public string Solve(string[] input)
        {
            long sum = 0;
            foreach (var line in input)
            {
                var expressionEvaluator = new ExpressionEvaluator();
                sum += expressionEvaluator.Evaluate(line, false);
            }

            return sum.ToString();
        }
    }
}
