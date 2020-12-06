using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day5
{
    class SeatConverter
    {
        internal uint GetSeatId(string identifier)
        {
            var binary = identifier.Select(a => a == 'B' || a == 'R').Reverse().ToArray();
            var bitArray = new BitArray(binary);

            var uintArray = new uint[1];
            bitArray.CopyTo(uintArray, 0);

            return uintArray[0];
        }
    }
}
