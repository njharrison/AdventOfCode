using AdventOfCode.Tasks;


namespace AdventOfCode.Day05
{
    class Task1 : ITask
    {
        public long Solve(string[] input)
        {
            var seatConverter = new SeatConverter();

            long maxSeatId = 0;

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
