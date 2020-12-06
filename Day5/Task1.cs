using AdventOfCode.Tasks;


namespace AdventOfCode.Day5
{
    class Task1 : ITask
    {
        public uint Solve(string[] input)
        {
            var seatConverter = new SeatConverter();

            uint maxSeatId = 0;

            foreach (var line in input)
            {
                var seatId = seatConverter.GetSeatId(line);
                if (seatId > maxSeatId)
                {
                    maxSeatId = seatId;
                }
            }

            return maxSeatId;
        }
    }
}
