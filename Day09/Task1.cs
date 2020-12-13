using AdventOfCode.Library;
using AdventOfCode.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day09
{
    class Task1 : Day09TaskBase, ITask
    {
        protected override ulong ProcessResult(IList<ulong> encodingQueue, int queueIndex)
        {
            return encodingQueue[queueIndex];
        }
    }
}
