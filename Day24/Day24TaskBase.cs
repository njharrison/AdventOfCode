using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day24
{
    abstract internal class Day24TaskBase
    {
        protected List<List<Tuple<int, int>>> ParseInput(string[] input)
        {
            var allInstructions = new List<List<Tuple<int, int>>>();
            foreach (var line in input)
            {
                var instructionList = new List<Tuple<int, int>>();
                for (int i = 0; i < line.Length; i++)
                {
                    var up = 0;
                    var right = 0;
                    if (line[i] == 'n')
                    {
                        up = 1;
                        i++;
                    }
                    else if (line[i] == 's')
                    {
                        up = -1;
                        i++;
                    }

                    if (line[i] == 'e')
                    {
                        right = 1;
                    }
                    else if (line[i] == 'w')
                    {
                        right = -1;
                    }

                    if (up == 0)
                    {
                        right = 2 * right;
                    }

                    instructionList.Add(new Tuple<int, int>(right, up));
                }

                allInstructions.Add(instructionList);
            }

            return allInstructions;
        }

        internal Dictionary<Tuple<int, int>, bool> GetState(string[] input)
        {
            var allInstructions = this.ParseInput(input);

            var endState = new Dictionary<Tuple<int, int>, bool>();

            foreach (var instructionSet in allInstructions)
            {
                var right = instructionSet.Sum(a => a.Item1);
                var up = instructionSet.Sum(a => a.Item2);
                var tuple = new Tuple<int, int>(right, up);

                if (endState.ContainsKey(tuple))
                {
                    endState[tuple] = !endState[tuple];
                }
                else
                {
                    endState.Add(tuple, true);
                }
            }

            return endState;
        }
    }
}