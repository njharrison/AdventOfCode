using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Day03
{
    class TreeCounter
    {
        public ulong CountTrees(string[] input, int rightSkip, int downSkip)
        {
            var rightIndex = 0;
            var downIndex = 0;

            ulong treeCount = 0;

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
