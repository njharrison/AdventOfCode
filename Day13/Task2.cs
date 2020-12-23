using AdventOfCode.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day13
{
    class Task2 : Day13TaskBase, ITask
    {
        public string Solve(string[] input)
        {
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

            var maxIndex = -1;

            for (var i = 0; i < schedules.Length; i++)
            {
                if (schedules[i] != ulong.MaxValue && (maxIndex == -1 || schedules[i] > schedules[maxIndex]))
                {
                    maxIndex = i;
                }
            }

            var alreadyFactorised = new HashSet<ulong>
            {
                schedules[maxIndex],
                ulong.MaxValue
            };

            var timeSkip = schedules[maxIndex];

            var testTime = schedules[maxIndex] - (ulong)maxIndex;
            var complete = false;
            while (!complete)
            {
                testTime += timeSkip;
                complete = true;
                for (ulong i = 0; i < (ulong)schedules.Length; i++)
                {
                    if (!alreadyFactorised.Contains(schedules[i]))
                    {
                        if ((testTime + i) % schedules[i] == 0)
                        {
                            timeSkip *= schedules[i];
                            alreadyFactorised.Add(schedules[i]);
                        }
                        else
                        {
                            complete = false;
                        }
                    }
                }
            }

            return testTime.ToString();
        }
    }
}
