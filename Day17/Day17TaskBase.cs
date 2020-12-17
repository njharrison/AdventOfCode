using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day17
{
    abstract internal class Day17TaskBase
    {
        protected Cube3D Construct3DCubeFromInput(string[] input)
        {
            var cube = new Cube3D();

            for (var y = 0; y < input.Length; y++)
            {
                var line = input[y];
                for (var x = 0; x < line.Length; x++)
                {
                    if (line[x] == '#')
                    {
                        var point = new Point3D(x, y, 0);
                        cube.Add(point.UniqueIdentifier, point);
                    }
                }
            }

            return cube;
        }

        protected Cube4D Construct4DCubeFromInput(string[] input)
        {
            var cube = new Cube4D();

            for (var y = 0; y < input.Length; y++)
            {
                var line = input[y];
                for (var x = 0; x < line.Length; x++)
                {
                    if (line[x] == '#')
                    {
                        var point = new Point4D(x, y, 0, 0);
                        cube.Add(point.UniqueIdentifier, point);
                    }
                }
            }

            return cube;
        }

        internal Cube3D Iterate(Cube3D cube)
        {
            var minX = cube.Min(a => a.Value.X) - 1;
            var minY = cube.Min(a => a.Value.Y) - 1;
            var minZ = cube.Min(a => a.Value.Z) - 1;

            var maxX = cube.Max(a => a.Value.X) + 1;
            var maxY = cube.Max(a => a.Value.Y) + 1;
            var maxZ = cube.Max(a => a.Value.Z) + 1;

            var newCube = new Cube3D();

            for (var x = minX; x <= maxX; x++)
            {
                for (var y = minY; y <= maxY; y++)
                {
                    for (var z = minZ; z <= maxZ; z++)
                    {
                        var trialPoint = new Point3D(x, y, z);

                        var adjacentCount = cube.FindAdjacentCount(trialPoint);

                        if (cube.Any(a => a.Key == trialPoint.UniqueIdentifier))
                        {
                            if (adjacentCount == 2 || adjacentCount == 3)
                            {
                                newCube.Add(trialPoint.UniqueIdentifier, trialPoint);
                            }
                        }
                        else
                        {
                            if (adjacentCount == 3)
                            {
                                newCube.Add(trialPoint.UniqueIdentifier, trialPoint);
                            }
                        }
                    }
                }
            }

            return newCube;
        }

        internal Cube4D Iterate(Cube4D cube)
        {
            var minX = cube.Min(a => a.Value.X) - 1;
            var minY = cube.Min(a => a.Value.Y) - 1;
            var minZ = cube.Min(a => a.Value.Z) - 1;
            var minW = cube.Min(a => a.Value.W) - 1;

            var maxX = cube.Max(a => a.Value.X) + 1;
            var maxY = cube.Max(a => a.Value.Y) + 1;
            var maxZ = cube.Max(a => a.Value.Z) + 1;
            var maxW = cube.Max(a => a.Value.W) + 1;

            var newCube = new Cube4D();

            for (var x = minX; x <= maxX; x++)
            {
                for (var y = minY; y <= maxY; y++)
                {
                    for (var z = minZ; z <= maxZ; z++)
                    {
                        for (var w = minW; w <= maxW; w++)
                        {
                            var trialPoint = new Point4D(x, y, z, w);

                            var adjacentCount = cube.FindAdjacentCount(trialPoint);

                            if (cube.Any(a => a.Key == trialPoint.UniqueIdentifier))
                            {
                                if (adjacentCount == 2 || adjacentCount == 3)
                                {
                                    newCube.Add(trialPoint.UniqueIdentifier, trialPoint);
                                }
                            }
                            else
                            {
                                if (adjacentCount == 3)
                                {
                                    newCube.Add(trialPoint.UniqueIdentifier, trialPoint);
                                }
                            }
                        }
                    }
                }
            }

            return newCube;
        }

        protected void WriteCubeToConsole(Cube3D cube)
        {
            for (var z = cube.Min(a => a.Value.Z); z <= cube.Max(a => a.Value.Z); z++)
            {
                Console.WriteLine("z=" + z);

                for (var y = cube.Min(a => a.Value.Y); y <= cube.Max(a => a.Value.Y); y++)
                {
                    for (var x = cube.Min(a => a.Value.X); x <= cube.Max(a => a.Value.X); x++)
                    {
                        var point = new Point3D(x, y, z);
                        if (cube.ContainsKey(point.UniqueIdentifier))
                        {
                            Console.Write('#');
                        }
                        else
                        {
                            Console.Write('.');
                        }
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}