using AdventOfCode.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day12
{
    class Task1 : Day12TaskBase, ITask
    {
        public ulong Solve(string[] input)
        {
            var x = 0.0;
            var y = 0.0;
            var heading = 0;

            foreach (var instruction in input)
            {
                var movement = instruction[0];
                var value = int.Parse(new string(instruction.Skip(1).ToArray()));

                switch (movement)
                {
                    case 'N':
                        y += value;
                        break;
                    case 'S':
                        y -= value;
                        break;
                    case 'E':
                        x += value;
                        break;
                    case 'W':
                        x -= value;
                        break;
                    case 'L':
                        heading += value;
                        heading %= 360;
                        break;
                    case 'R':
                        heading -= value;
                        heading %= 360;
                        break;
                    case 'F':
                        x += Math.Cos(ConvertToRadians(heading)) * value;
                        y += Math.Sin(ConvertToRadians(heading)) * value;
                        break;
                }
            }

            return (ulong)(Math.Abs(x) + Math.Abs(y));
        }


        
    }
}
