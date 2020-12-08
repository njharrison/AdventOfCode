using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day05
{
    class SeatConverter
    {
        internal long GetSeatId(string identifier)
        {
            var binary = identifier.Select(a => a == 'B' || a == 'R').Reverse().ToArray();
            var bitArray = new BitArray(binary);

            var longArray = new uint[1];
            bitArray.CopyTo(longArray, 0);

            return longArray[0];
        }
    }
}
