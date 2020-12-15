using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day15
{
    abstract internal class Day15TaskBase
    {
        protected ulong Solve(string[] input, ulong count)
        {
            var startingNumbers = input[0].Split(',').Select(a => ulong.Parse(a)).ToArray();

            ulong turn = 0;

            var numberRecord = new Dictionary<ulong, Queue<ulong>>();

            ulong lastNumberSpoken = 0;
            ulong thisNumberSpoken = 0;

            while (turn != count)
            {
                if (turn < (ulong)startingNumbers.Length)
                {
                    thisNumberSpoken = startingNumbers[turn];
                }
                else
                {
                    if (numberRecord[lastNumberSpoken].Count == 1)
                    {
                        thisNumberSpoken = 0;
                    }
                    else
                    {
                        thisNumberSpoken = numberRecord[lastNumberSpoken].Last() - numberRecord[lastNumberSpoken].First();
                    }
                }

                if (!numberRecord.ContainsKey(thisNumberSpoken))
                {
                    numberRecord.Add(thisNumberSpoken, new Queue<ulong>());
                }

                numberRecord[thisNumberSpoken].Enqueue(turn);
                if (numberRecord[thisNumberSpoken].Count > 2)
                {
                    numberRecord[thisNumberSpoken].Dequeue();
                }

                lastNumberSpoken = thisNumberSpoken;
                turn++;
            }

            return (ulong)lastNumberSpoken;
        }
    }
}