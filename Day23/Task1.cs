using AdventOfCode.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day23
{
    class Task1 : Day23TaskBase, ITask
    {
        public string Solve(string[] input)
        {
            var cups = input[0].Select(a => int.Parse(new[] { a })).ToList();

            cups = PlayGameLinkedList(cups, 100);

            var oneIndex = cups.IndexOf(1);
            var returnValue = string.Empty;
            for (int i = 0; i < cups.Count - 1; i++)
            {
                returnValue += cups[(i + oneIndex + 1) % cups.Count];
            }

            return returnValue;
        }
    }
}
