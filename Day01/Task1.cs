using AdventOfCode.Library;
using AdventOfCode.Tasks;
using System.Linq;

namespace AdventOfCode.Day01
{
    class Task1 : ITask
    {
        public long Solve(string[] input)
        {
            var actualArray = input.Select(a => long.Parse(a));

            var result = ArrayCheck.FindTwoValuesWithSum(actualArray, 2020);

            return result.Item1 * result.Item2;

            throw new System.ArgumentException("Argument must contain two integers that sum to 2020");
        }
    }
}
