using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day19
{
    abstract internal class Day19TaskBase
    {

        protected ulong SolveForInput(string[] input)
        {
            var rootNode = this.ParseRules(input);
            var inputData = this.GetInputData(input);

            var successCount = 0;

            foreach (var inputLine in inputData)
            {
                var matched = this.GetMatchOptions(new List<string>() { inputLine }, rootNode);
                if (matched.Any(a => a == string.Empty))
                {
                    //Console.WriteLine(inputLine);
                    successCount++;
                }
            }

            return (ulong)successCount;
        }

        protected RuleNode ParseRules(string[] input)
        {
            Dictionary<int, RuleNode> rulesCache = new Dictionary<int, RuleNode>();
            
            foreach (var line in input)
            {
                var rule = line.Split(':');
                if (rule.Length == 2)
                {
                    rulesCache.Add(int.Parse(rule[0]), new RuleNode(rule[1]));
                }
            }

            foreach (var rule in rulesCache)
            {
                var ruleString = rule.Value.Rule.Trim();

                if (!ruleString.Contains('"'))
                {
                    var options = ruleString.Split("|");

                    foreach (var option in options)
                    {
                        var ruleChildren = new List<RuleNode>();
                        rule.Value.ChildNodes.Add(ruleChildren);

                        var rulesInOption = option.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                        foreach (var ruleInOption in rulesInOption)
                        {
                            ruleChildren.Add(rulesCache[int.Parse(ruleInOption)]);
                        }
                    }
                }
                else
                {
                    rule.Value.Rule = rule.Value.Rule.Trim().Replace("\"", "");
                }
            }

            return rulesCache[0];
        }

        protected string[] GetInputData(string[] input)
        {
            return input.Where(a => a.Length > 0 && !a.Contains(":")).ToArray();
        }

        protected List<string> GetMatchOptions(List<string> input, RuleNode rule)
        {
            var possibleReturns = new List<string>();

            if (!input.Any())
            {
                return possibleReturns;
            }

            foreach (var inputOption in input)
            {
                if (rule.ChildNodes.Count > 0)
                {
                    foreach (var individualOption in rule.ChildNodes)
                    {
                        var matchOptions = input.ToList();
                        foreach (var optionPart in individualOption)
                        {
                            if (matchOptions.Count > 0)
                            {
                                matchOptions = GetMatchOptions(matchOptions, optionPart);
                            }
                        }

                        possibleReturns.AddRange(matchOptions);
                    }
                }
                else
                {
                    if (inputOption.StartsWith(rule.Rule))
                    {
                        possibleReturns.Add(inputOption[rule.Rule.Length..]);
                    }
                }
            }

            return possibleReturns.Distinct().ToList();
        }
    }
}