using System.Collections.Generic;

namespace AdventOfCode.Day07
{
    public class BagDefinition
    {
        readonly Dictionary<string, ulong> childBags = new Dictionary<string, ulong>();

        public BagDefinition(string colour)
        {
            Colour = colour;
        }

        public string Colour { get; }

        public Dictionary<string, ulong> ChildBags => childBags;
    }
}