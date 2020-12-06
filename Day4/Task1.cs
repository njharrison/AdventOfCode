using AdventOfCode.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day4
{
    class Task1 : IPassportVerifier, ITask
    {
        readonly string[] requiredFields = new[] { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };

        public bool PassportValid(Dictionary<string, string> passport)
        {
            return requiredFields.All(a => passport.ContainsKey(a));
        }

        public uint Solve(string[] input)
        {
            var passportListValidCounter = new PassportListValidCounter(this);

            return passportListValidCounter.CalculateValidCount(input);
        }
    }
}
