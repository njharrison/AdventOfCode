using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Day3
{
    class TreeCounter
    {
        public uint CountTrees(string[] input, int rightSkip, int downSkip)
        {
            var rightIndex = 0;
            var downIndex = 0;

            uint treeCount = 0;

            while (downIndex < input.Length)
            {
                var line = input[downIndex];

                rightIndex %= line.Length;

                if (line[rightIndex] == '#')
                {
                    treeCount++;
                }
                rightIndex += rightSkip;
                downIndex += downSkip;
            }

            return treeCount;
        }
    }
}
