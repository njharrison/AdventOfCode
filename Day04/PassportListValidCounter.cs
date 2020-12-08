using System.Collections.Generic;

namespace AdventOfCode.Day04
{
    internal class PassportListValidCounter
    {
        private readonly IPassportVerifier passportVerifier;

        public PassportListValidCounter(IPassportVerifier passportVerifier)
        {
            this.passportVerifier = passportVerifier;
        }

        public long CalculateValidCount(string[] input)
        {
            var passportList = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>()
            };

            foreach (var line in input)
            {
                if (line == "")
                {
                    passportList.Add(new Dictionary<string, string>());
                }
                else
                {
                    var items = line.Split(' ');
                    foreach (var item in items)
                    {
                        var kvp = item.Split(':');
                        passportList[^1].Add(kvp[0], kvp[1]);
                    }
                }
            }

            long validPassportCount = 0;

            foreach (var passport in passportList)
            {
                if (this.passportVerifier.PassportValid(passport))
                {
                    validPassportCount++;
                }
            }

            return validPassportCount;
        }
    }
}