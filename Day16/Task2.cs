using AdventOfCode.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day16
{
    class Task2 : Day17TaskBase, ITask
    {
        public ulong Solve(string[] input)
        {
            GetRulesAndTickets(input, out Dictionary<string, List<Tuple<int, int>>> rules, out List<int[]> tickets);
            tickets = StripInvalidTickets(tickets, rules);

            var ruleIndices = new Dictionary<int, List<string>>();
            for (int i = 0; i < rules.Count; i++)
            {
                var rulesForIndex = FindRuleForIndex(tickets, i, rules);

                
                ruleIndices.Add(i, rulesForIndex);
            }

            var sortedRuleIndices = ruleIndices.OrderBy(a => a.Value.Count).ToArray();

            for (var i = 0; i < sortedRuleIndices.Length; i++)
            {
                var ruleName = sortedRuleIndices[i].Value[0];
                for (var j = i + 1; j < sortedRuleIndices.Length; j++)
                {
                    sortedRuleIndices[j].Value.Remove(ruleName);
                }
            }

            ulong myProduct = 1;
            foreach (var rule in sortedRuleIndices)
            {
                if (rule.Value[0].Contains("departure"))
                {
                    myProduct *= (ulong)tickets[0][rule.Key];
                }
            }
            
            return myProduct;
        }

        private List<string> FindRuleForIndex(List<int[]> tickets, int valueIndex, Dictionary<string, List<Tuple<int, int>>> rules)
        {
            var validRules = new List<string>();
            foreach (var rule in rules)
            {
                var ruleIsValid = true;
                foreach (var ticket in tickets)
                {
                    var value = ticket[valueIndex];

                    var valueIsValid = false;
                    foreach (var range in rule.Value)
                    {
                        if (value >= range.Item1 && value <= range.Item2)
                        {
                            valueIsValid = true;
                        }
                    }

                    if (!valueIsValid)
                    {
                        ruleIsValid = false;
                        break;
                    }
                }

                if (ruleIsValid)
                {
                    validRules.Add(rule.Key);
                }
            }

            return validRules;
        }

        private List<int[]> StripInvalidTickets(List<int[]> tickets, Dictionary<string, List<Tuple<int, int>>> rules)
        {
            var strippedTickets = new List<int[]>();
            foreach (var ticket in tickets)
            {
                var isValid = CheckAllRules(ticket, rules);
                if (isValid)
                {
                    strippedTickets.Add(ticket);
                }
            }

            return strippedTickets;
        }

        private bool CheckAllRules(int[] ticket, Dictionary<string, List<Tuple<int, int>>> rules)
        {
            foreach (var value in ticket)
            {
                var isValid = IsValueValid(rules, value);

                if (!isValid)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
