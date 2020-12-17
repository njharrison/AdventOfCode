using System;
using System.Collections.Generic;


namespace AdventOfCode.Day17
{
    class Cube4D : SortedList<long, Point4D>
    {
        internal int FindAdjacentCount(Point4D trialPoint)
        {
            var adjacentCubes = 0;

            for (var x = trialPoint.X - 1; x <= trialPoint.X + 1; x++)
            {
                for (var y = trialPoint.Y - 1; y <= trialPoint.Y + 1; y++)
                {
                    for (var z = trialPoint.Z - 1; z <= trialPoint.Z + 1; z++)
                    {
                        for (var w = trialPoint.W - 1; w <= trialPoint.W + 1; w++)
                        {
                            if (x != trialPoint.X || y != trialPoint.Y || z != trialPoint.Z || w != trialPoint.W)
                            {
                                var adjacentPoint = new Point4D(x, y, z, w);

                                if (this.ContainsKey(adjacentPoint.UniqueIdentifier))
                                {
                                    adjacentCubes++;
                                }
                            }
                        }
                    }
                }
            }

            return adjacentCubes;
        }
    }
}
