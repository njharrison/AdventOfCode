using AdventOfCode.Tasks;
using System.Linq;

namespace AdventOfCode.Day01
{
    class Task1 : ITask
    {
        public string Solve(string[] input)
        {
            var actualArray = input.Select(a => ulong.Parse(a));

            var result = ArrayCheck.FindTwoValuesWithSum(actualArray, 2020);

            return (result.Item1 * result.Item2).ToString();

            throw new System.ArgumentException("Argument must contain two integers that sum to 2020");
        }
    }
}
