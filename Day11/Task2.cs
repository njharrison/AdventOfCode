using AdventOfCode.Library;
using AdventOfCode.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day11
{
    class Task2 : Day11TaskBase, ITask
    {
        protected override void ApplySeatingRules(char[,] input, ref char[,] result, int centreX, int centreY)
        {
            var occupiedSeats = 0;

            if (input[centreX, centreY] == floor)
            {
                return;
            }

            for (var xDirection = -1; xDirection <= 1; xDirection++)
            {
                for (var yDirection = -1; yDirection <= 1; yDirection++)
                {
                    if (xDirection != 0 || yDirection != 0)
                    {
                        var closestSeat = FindClosestSeatInDirection(input, centreX, centreY, xDirection, yDirection);
                        if (closestSeat == occupiedSeat)
                        {
                            occupiedSeats++;
                        }
                    }
                }
            }

            if (input[centreX, centreY] == occupiedSeat && occupiedSeats >= 5)
            {
                result[centreX, centreY] = unoccupiedSeat;
            }
            else if (input[centreX, centreY] == unoccupiedSeat && occupiedSeats == 0)
            {
                result[centreX, centreY] = occupiedSeat;
            }
        }

        private char FindClosestSeatInDirection(char[,] input, int centreX, int centreY, int xDirection, int yDirection)
        {
            var closestSeat = floor;
            var currentX = centreX;
            var currentY = centreY;
            while (currentX >= 0 && currentY >= 0
                && currentX < input.GetLength(0) && currentY < input.GetLength(1)
                && closestSeat == floor)
            {
                if (currentX != centreX || currentY != centreY)
                {
                    closestSeat = input[currentX, currentY];
                }

                currentX += xDirection;
                currentY += yDirection;
            }

            return closestSeat;
        }
    }
}
