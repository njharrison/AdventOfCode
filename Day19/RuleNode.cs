using System.Collections.Generic;

namespace AdventOfCode.Day19
{
    internal class RuleNode
    {
        public List<List<RuleNode>> ChildNodes { get; }

        public string Rule { get; set; }

        public RuleNode(string rule)
        {
            Rule = rule;
            ChildNodes = new List<List<RuleNode>>();
        }
    }
}