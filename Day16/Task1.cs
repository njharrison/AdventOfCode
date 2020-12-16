using AdventOfCode.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day16
{
    class Task1 : Day16TaskBase, ITask
    {
        public ulong Solve(string[] input)
        {
            GetRulesAndTickets(input, out Dictionary<string, List<Tuple<int, int>>> rules, out List<int[]> tickets);

            ulong total = 0;
            foreach (var ticket in tickets)
            {
                var allInvalidValues = CheckAllRules(ticket, rules);
                total += (ulong)allInvalidValues.Sum();
            }

            return total;
        }



        private List<int> CheckAllRules(int[] ticket, Dictionary<string, List<Tuple<int, int>>> rules)
        {
            var result = new List<int>();

            foreach (var value in ticket)
            {
                var isValid = IsValueValid(rules, value);

                if (!isValid)
                {
                    result.Add(value);
                }
            }

            return result;
        }
    }
}
