using AdventOfCode.Library;
using AdventOfCode.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day11
{
    class Task1 : Day11TaskBase, ITask
    {
        protected override void ApplySeatingRules(char[,] input, ref char[,] result, int centreX, int centreY)
        {
            var occupiedSeats = 0;

            if (input[centreX, centreY] == floor)
            {
                return;
            }

            for (var i = centreX - 1; i <= centreX + 1; i++)
            {
                for (var j = centreY - 1; j <= centreY + 1; j++)
                {
                    if (i >= 0 && i < input.GetLength(0)
                        && j >=0 && j < input.GetLength(1))
                    {
                        if ((i != centreX || j != centreY) && input[i, j] == occupiedSeat)
                        {
                            occupiedSeats++;
                        }
                    }
                }
            }

            if (input[centreX, centreY] == occupiedSeat && occupiedSeats >= 4)
            {
                result[centreX, centreY] = unoccupiedSeat;
            }
            else if (input[centreX, centreY] == unoccupiedSeat && occupiedSeats == 0)
            {
                result[centreX, centreY] = occupiedSeat;
            }
        }
    }
}
