using AdventOfCode.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day17
{
    class Task2 : Day17TaskBase, ITask
    {
        public string Solve(string[] input)
        {
            var cube = base.Construct4DCubeFromInput(input);

            for (int i = 0; i < 6; i++)
            {
                //base.WriteCubeToConsole(cube);

                cube = base.Iterate(cube);
            }

            return cube.Count.ToString();
        }
    }
}
