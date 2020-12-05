﻿using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day2
{
    class Task1
    {
        public int Solve(string[] input)
        {
            var passwordDefinitionRegex = new Regex("(?<Minimum>.*)\\-(?<Maximum>.*)\\ (?<Letter>.*)\\:\\ (?<Password>.*)");

            var actualArray = input.Select(a => passwordDefinitionRegex.Match(a));

            var validPasswords = 0;

            foreach (var item in actualArray)
            {
                var minimum = int.Parse(item.Groups["Minimum"].Value);
                var maximum = int.Parse(item.Groups["Maximum"].Value);
                var letter = item.Groups["Letter"].Value[0];
                var password = item.Groups["Password"].Value;

                var actualCount = password.Count(a => a == letter);

                if (actualCount >= minimum && actualCount <= maximum)
                {
                    validPasswords++;
                }
            }

            return validPasswords;
        }
    }
}
