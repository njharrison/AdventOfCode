using AdventOfCode.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day6
{
    class Task1 : Day6TaskBase, ITask
    {
        public uint Solve(string[] input)
        {
            List<List<string>> passengers = GetPassengerIssuesList(input);

            var passengerIssues = passengers.Select(a =>
            {
                var result = a.Aggregate(string.Empty, (a, b) => a + b, c => c);
                return result.Distinct().Count();
            }).ToList();

            var result = passengerIssues.Aggregate(0, (a, b) => a + b, c => (uint)c);

            return result;
        }
    }
}
