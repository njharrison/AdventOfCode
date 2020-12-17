using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day16
{
    abstract internal class Day17TaskBase
    {
        protected void GetRulesAndTickets(string[] input, out Dictionary<string, List<Tuple<int, int>>> rules, out List<int[]> tickets)
        {
            var ruleRegex = new Regex(@"(?<FieldName>.*?)\:\ (?<Start1>\d*)\-(?<End1>\d*)\ or\ (?<Start2>\d*)\-(?<End2>\d*)");
            rules = new Dictionary<string, List<Tuple<int, int>>>();
            tickets = new List<int[]>();
            foreach (var line in input)
            {
                var match = ruleRegex.Match(line);
                if (match.Success)
                {
                    rules.Add(match.Groups["FieldName"].Value, new List<Tuple<int, int>>()
                        {
                            new Tuple<int, int>(int.Parse(match.Groups["Start1"].Value), int.Parse(match.Groups["End1"].Value)),
                            new Tuple<int, int>(int.Parse(match.Groups["Start2"].Value), int.Parse(match.Groups["End2"].Value))
                        });
                }
                else
                {
                    var commaSeparatedItems = line.Split(',');
                    if (commaSeparatedItems.Length == rules.Count)
                    {
                        tickets.Add(commaSeparatedItems.Select(a => int.Parse(a)).ToArray());
                    }
                }
            }
        }

        protected bool IsValueValid(Dictionary<string, List<Tuple<int, int>>> rules, int value)
        {
            var isValid = false;
            foreach (var rule in rules.Values)
            {
                foreach (var range in rule)
                {
                    if (value >= range.Item1 && value <= range.Item2)
                    {
                        isValid = true;
                    }
                }
            }

            return isValid;
        }
    }
}