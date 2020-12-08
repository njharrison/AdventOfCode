using AdventOfCode.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day06
{
    class Task1 : Day06TaskBase, ITask
    {
        public long Solve(string[] input)
        {
            List<List<string>> passengers = GetPassengerIssuesList(input);

            var passengerIssues = passengers.Select(a =>
            {
                var result = a.Aggregate(string.Empty, (a, b) => a + b, c => c);
                return result.Distinct().Count();
            }).ToList();

            var result = passengerIssues.Aggregate(0, (a, b) => a + b, c => (long)c);

            return result;
        }
    }
}
