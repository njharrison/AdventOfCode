using AdventOfCode.Library;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day09
{
    abstract internal class Day09TaskBase
    {
        const int queueLength = 25;

        protected abstract ulong ProcessResult(IList<ulong> encodingQueue, int queueIndex);

        public ulong Solve(string[] input)
        {
            var encodingList = input.Select(a => ulong.Parse(a)).ToList();

            var encodingQueue = new Queue<ulong>(queueLength);

            for (var index = 0; index < encodingList.Count; index++)
            {
                if (encodingQueue.Count == 25)
                {
                    // Do the checks
                    var result = ArrayCheck.FindTwoValuesWithSum(encodingQueue, encodingList[index]);

                    if (result == null)
                    {
                        return this.ProcessResult(encodingList, index);
                    }

                    encodingQueue.Dequeue();
                }

                encodingQueue.Enqueue(encodingList[index]);
            }

            return ulong.MinValue;
        }
    }
}