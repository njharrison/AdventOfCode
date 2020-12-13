using AdventOfCode.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day07
{
    class Task1 : ITask
    {
        public ulong Solve(string[] input)
        {
            var bagParser = new BagInputParser();

            var bagDefinitionList = bagParser.GetBagDefinitions(input);

            var result = SearchBagPaths("shiny gold", bagDefinitionList);

            return (ulong)result.Count;
        }

        private List<string> SearchBagPaths(string bagColour, List<BagDefinition> bagDefinitions)
        {
            var parentBagNames = new List<string>();
            foreach (var bagDefinition in bagDefinitions)
            {
                if (bagDefinition.ChildBags.ContainsKey(bagColour))
                {
                    parentBagNames.Add(bagDefinition.Colour);
                }
            }

            var parentBagResults = new List<string>();

            foreach (var parentBagColour in parentBagNames)
            {
                parentBagResults.AddRange(SearchBagPaths(parentBagColour, bagDefinitions));
            }

            return parentBagNames.Concat(parentBagResults).Distinct().ToList();
        }
    }
}
