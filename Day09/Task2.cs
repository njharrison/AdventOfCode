using AdventOfCode.Library;
using AdventOfCode.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day09
{
    class Task2 : Day09TaskBase, ITask
    {
        protected override long ProcessResult(IList<long> encodingList, int listIndex)
        {
            var desiredValue = encodingList[listIndex];

            for (var i = 0; i < listIndex; i++)
            {
                long sum = 0;
                var j = i;
                while (j < listIndex && sum < desiredValue)
                {
                    sum += encodingList[j++];
                }

                if (sum == desiredValue)
                {
                    return encodingList[i] + encodingList[j-1];
                }
            }

            return -1;
        }
    }
}
