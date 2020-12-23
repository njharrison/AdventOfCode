using AdventOfCode.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day12
{
    class Task2 : Day12TaskBase, ITask
    {
        public string Solve(string[] input)
        {
            var x = 0.0;
            var y = 0.0;
            var wayPointXDelta = 10.0;
            var wayPointYDelta = 1.0;

            foreach (var instruction in input)
            {
                var movement = instruction[0];
                var value = int.Parse(new string(instruction.Skip(1).ToArray()));

                Tuple<double, double> newWaypoint;

                switch (movement)
                {
                    case 'N':
                        wayPointYDelta += value;
                        break;
                    case 'S':
                        wayPointYDelta -= value;
                        break;
                    case 'E':
                        wayPointXDelta += value;
                        break;
                    case 'W':
                        wayPointXDelta -= value;
                        break;
                    case 'L':
                        newWaypoint = RotatePoint(wayPointXDelta, wayPointYDelta, value);
                        wayPointXDelta = newWaypoint.Item1;
                        wayPointYDelta = newWaypoint.Item2;
                        break;
                    case 'R':
                        newWaypoint = RotatePoint(wayPointXDelta, wayPointYDelta, -value);
                        wayPointXDelta = newWaypoint.Item1;
                        wayPointYDelta = newWaypoint.Item2;
                        break;
                    case 'F':
                        x += wayPointXDelta * value;
                        y += wayPointYDelta * value;
                        break;
                }
            }

            return (Math.Abs(x) + Math.Abs(y)).ToString();
        }

        private Tuple<double, double> RotatePoint(double wayPointXDelta, double wayPointYDelta, int angle)
        {
            double sin = Math.Sin(ConvertToRadians(angle));
            double cos = Math.Cos(ConvertToRadians(angle));

            return new Tuple<double, double>(wayPointXDelta * cos - wayPointYDelta * sin, wayPointYDelta * cos + wayPointXDelta * sin);
        }
    }
}
