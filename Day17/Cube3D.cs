using System;
using System.Collections.Generic;


namespace AdventOfCode.Day17
{
    class Cube3D : SortedList<long, Point3D>
    {
        internal int FindAdjacentCount(Point3D trialPoint)
        {
            var adjacentCubes = 0;

            for (var x = trialPoint.X - 1; x <= trialPoint.X + 1; x++)
            {
                for (var y = trialPoint.Y - 1; y <= trialPoint.Y + 1; y++)
                {
                    for (var z = trialPoint.Z - 1; z <= trialPoint.Z + 1; z++)
                    {
                        if (x != trialPoint.X || y != trialPoint.Y || z != trialPoint.Z)
                        {
                            var adjacentPoint = new Point3D(x, y, z);

                            if (this.ContainsKey(adjacentPoint.UniqueIdentifier))
                            {
                                adjacentCubes++;
                            }
                        }
                    }
                }
            }

            return adjacentCubes;
        }
    }
}
