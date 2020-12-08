using AdventOfCode.Tasks;
using System.Linq;

namespace AdventOfCode.Day01
{
    class Task1 : ITask
    {
        public long Solve(string[] input)
        {
            var actualArray = input.Select(a => long.Parse(a));

            foreach (var item1 in actualArray)
            {
                foreach (var item2 in actualArray)
                {
                    if (item1 + item2 == 2020)
                    {
                        return item1 * item2;
                    }
                }
            }

            throw new System.ArgumentException("Argument must contain two integers that sum to 2020");
        }
    }
}
