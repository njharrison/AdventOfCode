using AdventOfCode.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day20
{
    class Task1 : Day20TaskBase, ITask
    {
        public string Solve(string[] input)
        {
            var tiles = this.ParseInputs(input);

            List<Tile> cornerMatches = FindCorners(tiles);

            return cornerMatches.Aggregate((ulong)1, (a, b) => a * (ulong)b.Key).ToString();
        }
    }
}
