using AdventOfCode.Questions._2020;
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
        public ulong Solve2(string[] input)
        {
            ulong sum = 0;
            var expressionEvaluator = new ExpressionEvaluator();
            foreach (var line in input)
            {
                sum += (ulong)expressionEvaluator.Evaluate(line, true);
            }

            return sum;
        }

        public ulong Solve(string[] input)
        {
            var a = new Day18Question();

            var expressionEvaluator = new ExpressionEvaluator();

            var b = a.SolvePart2(input).ToList();

            var c = input.Select(a => expressionEvaluator.Evaluate(a, true)).ToList();

            for (var i = 0; i < b.Count; i++)
            {
                if (b[i] != c[i])
                {
                    Console.WriteLine(input[i]);
                }
            }

            Console.WriteLine(this.Solve2(input));

            Console.WriteLine(b);

            return (ulong)b.Sum();
        }
    }
}
