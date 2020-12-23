using AdventOfCode.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day23
{
    class Task2 : Day23TaskBase, ITask
    {
        public string Solve(string[] input)
        {
            var cups = input[0].Select(a => int.Parse(new[] { a })).ToList();

            for (var i = cups.Max(); i < 1000000; i++)
            {
                cups.Add(i + 1);
            }

            cups = PlayGameLinkedList(cups, 10000000);

            var oneIndex = cups.IndexOf(1);
            var cup1 = cups[(oneIndex + 1) % cups.Count];
            var cup2 = cups[(oneIndex + 2) % cups.Count];
            return ((ulong)cup1 * (ulong)cup2).ToString();
        }
    }
}
