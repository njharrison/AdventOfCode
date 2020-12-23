using AdventOfCode.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day13
{
    class Task1 : Day13TaskBase, ITask
    {
        public string Solve(string[] input)
        {
            ulong timeStamp = ulong.Parse(input[0]);

            var schedules = input[1].Split(',').Select(a =>
            {
                if (a == "x")
                {
                    return ulong.MaxValue;
                }
                else
                {
                    return ulong.Parse(a);
                }
            }).ToArray();

            var minWait = ulong.MaxValue;
            var minWaitBus = (ulong)0;
            foreach (var time in schedules)
            {
                var wait = time - timeStamp % time;

                if (wait < minWait)
                {
                    minWait = wait;
                    minWaitBus = time;
                }
            }

            return (minWait * minWaitBus).ToString();
        }
    }
}
