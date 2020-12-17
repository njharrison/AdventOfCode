using AdventOfCode.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day17
{
    class Task1 : Day17TaskBase, ITask
    {
        public ulong Solve(string[] input)
        {
            var cube = base.Construct3DCubeFromInput(input);

            for (int i = 0; i < 6; i++)
            {
                base.WriteCubeToConsole(cube);

                cube = base.Iterate(cube);
            }

            return (ulong)cube.Count;
        }
    }
}
