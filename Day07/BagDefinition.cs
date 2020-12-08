using System.Collections.Generic;

namespace AdventOfCode.Day07
{
    public class BagDefinition
    {
        readonly Dictionary<string, int> childBags = new Dictionary<string, int>();

        public BagDefinition(string colour)
        {
            Colour = colour;
        }

        public string Colour { get; }

        public Dictionary<string, int> ChildBags => childBags;
    }
}