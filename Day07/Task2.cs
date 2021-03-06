﻿using AdventOfCode.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day07
{
    class Task2 : ITask
    {
        public string Solve(string[] input)
        {
            var bagParser = new BagInputParser();

            var bagDefinitionList = bagParser.GetBagDefinitions(input);

            var result = SearchBagPaths("shiny gold", bagDefinitionList);

            return result.ToString();
        }

        private ulong SearchBagPaths(string bagColour, List<BagDefinition> bagDefinitions)
        {
            ulong result = 0;

            var bagDefinition = bagDefinitions.Find(a => a.Colour == bagColour);

            foreach (var childBag in bagDefinition.ChildBags)
            {
                result += childBag.Value;
                result += childBag.Value * SearchBagPaths(childBag.Key, bagDefinitions);
            }

            return result;
        }
    }
}
