using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day6
{
    internal class Day6TaskBase
    {
        protected List<List<string>> GetPassengerIssuesList(string[] input)
        {
            List<List<string>> passengers = new List<List<string>>
            {
                new List<string>()
            };

            foreach (var line in input)
            {
                if (line == "")
                {
                    passengers.Add(new List<string>());
                }
                else
                {
                    passengers.Last().Add(line);
                }
            }

            return passengers;
        }
    }
}