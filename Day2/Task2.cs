using AdventOfCode.Tasks;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day2
{
    class Task2 : ITask
    {
        public uint Solve(string[] input)
        {
            var passwordDefinitionRegex = new Regex("(?<Index1>.*)\\-(?<Index2>.*)\\ (?<Letter>.*)\\:\\ (?<Password>.*)");

            var actualArray = input.Select(a => passwordDefinitionRegex.Match(a));

            uint validPasswords = 0;

            foreach (var item in actualArray)
            {
                var index1 = int.Parse(item.Groups["Index1"].Value);
                var index2 = int.Parse(item.Groups["Index2"].Value);
                var letter = item.Groups["Letter"].Value[0];
                var password = item.Groups["Password"].Value;

                if ((password.Length >= index1 && password[index1 - 1] == letter)
                    ^ (password.Length >= index2 && password[index2 - 1] == letter))
                {
                    validPasswords++;
                }
            }

            return validPasswords;
        }
    }
}
