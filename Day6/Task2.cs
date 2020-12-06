using AdventOfCode.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day6
{
    class Task2 : Day6TaskBase, ITask
    {
        public uint Solve(string[] input)
        {
            List<List<string>> passengers = GetPassengerIssuesList(input);

            var passengerIssues = passengers.Select(a =>
            {
                var result = a.Skip(1).Aggregate((IEnumerable<char>)a.First(), (a, b) => a = a.Intersect(b), c => c);
                return result.Count();
            }).ToList();

            var result = passengerIssues.Aggregate(0, (a, b) => a + b, c => (uint)c);

            return result;
        }
    }
}
