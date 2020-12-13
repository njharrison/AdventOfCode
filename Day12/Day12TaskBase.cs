using AdventOfCode.Library;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day12
{
    abstract internal class Day12TaskBase
    {
        protected double ConvertToRadians(double angle)
        {
            return (Math.PI / 180) * angle;
        }
    }
}