using AdventOfCode.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day24
{
    class Task2 : Day24TaskBase, ITask
    {
        public string Solve(string[] input)
        {
            var startState = this.GetState(input);

            
            for (int i = 0; i < 100; i++)
            {
                var minX = startState.Min(a => a.Key.Item1 - 2);
                var maxX = startState.Max(a => a.Key.Item1 + 2);
                var minY = startState.Min(a => a.Key.Item2 - 2);
                var maxY = startState.Max(a => a.Key.Item2 + 2);

                var endState = new Dictionary<Tuple<int, int>, bool>();

                for (var x = minX; x <= maxX; x++)
                {
                    for (var y = minY; y <= maxY; y++)
                    {
                        if (y % 2 == 0 && x % 2 != 0)
                        {
                            continue;
                        }

                        if (y % 2 != 0 && x % 2 == 0)
                        {
                            continue;
                        }

                        var adjacentCount = GetAdjacentCount(x, y, startState);

                        var currentTuple = new Tuple<int, int>(x, y);
                        if (startState.ContainsKey(currentTuple) && startState[currentTuple])
                        {
                            if (adjacentCount == 1 || adjacentCount == 2)
                            {
                                endState.Add(currentTuple, true);
                            }
                        }
                        else
                        {
                            if (adjacentCount == 2)
                            {
                                endState.Add(currentTuple, true);
                            }
                        }
                    }
                }

                startState = endState;
            }

            return startState.Count(a => a.Value).ToString() + " out of " + startState.Count;
        }

        private int GetAdjacentCount(int centreX, int centreY, Dictionary<Tuple<int, int>, bool> state)
        {
            var tuples = new List<Tuple<int, int>>();
            tuples.Add(new Tuple<int, int>(centreX - 2, centreY));
            tuples.Add(new Tuple<int, int>(centreX + 2, centreY));
            tuples.Add(new Tuple<int, int>(centreX - 1, centreY - 1));
            tuples.Add(new Tuple<int, int>(centreX - 1, centreY + 1));
            tuples.Add(new Tuple<int, int>(centreX + 1, centreY - 1));
            tuples.Add(new Tuple<int, int>(centreX + 1, centreY + 1));

            return tuples.Count(a => state.ContainsKey(a) && state[a]);
        }
    }
}
