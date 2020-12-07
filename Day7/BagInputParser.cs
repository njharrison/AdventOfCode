using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day7
{
    class BagInputParser
    {
        public List<BagDefinition> GetBagDefinitions(string[] input)
        {
            var regex = new Regex(@"(?<ParentBagColour>.*?)\ bags\ contain(\ (?<ChildBagCount>\d*)\ (?<ChildBagColour>.*?)\ bag(s?)[,.])+");
            var regex2 = new Regex(@"(?<ParentBagColour>.*?)\ bags\ contain\ no\ other\ bags\.");

            var bagList = new List<BagDefinition>();

            foreach (string line in input)
            {
                var result = regex.Match(line);

                BagDefinition bagDefinition;

                if (!result.Success)
                {
                    result = regex2.Match(line);

                    if (!result.Success)
                    {
                        throw new ArgumentException("Invalid line: " + line);
                    }
                    bagDefinition = new BagDefinition(result.Groups["ParentBagColour"].Value);
                }
                else
                {
                    bagDefinition = new BagDefinition(result.Groups["ParentBagColour"].Value);

                    for (var i = 0; i < result.Groups["ChildBagColour"].Captures.Count; i++)
                    {
                        bagDefinition.ChildBags.Add(result.Groups["ChildBagColour"].Captures[i].Value, int.Parse(result.Groups["ChildBagCount"].Captures[i].Value));
                    }
                }

                bagList.Add(bagDefinition);
            }

            return bagList;
        }
    }
}
