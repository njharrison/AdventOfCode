using AdventOfCode.Tasks;
using System;
using System.Linq;

namespace AdventOfCode.Day5
{
    class Task2 : ITask
    {
        public long Solve(string[] input)
        {
            var seatConverter = new SeatConverter();

            var orderedSeats = input.Select(a => seatConverter.GetSeatId(a)).OrderBy(a => a).ToArray();

            for (var i = 1; i < orderedSeats.Length; i++)
            {
                if (orderedSeats[i] - orderedSeats[i - 1] > 1)
                {
                    return orderedSeats[i] - 1;
                }
            }

            throw new ArgumentException("Array must be contiguous with one exception");
        }
    }
}
