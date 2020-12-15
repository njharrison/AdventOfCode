using AdventOfCode.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day14
{
    class Task1 : Day15TaskBase, ITask
    {
        public ulong Solve(string[] input)
        {
            var zeroMask = new BitArray(36);
            var oneMask = new BitArray(36);

            var memoryAddresses = new Dictionary<int, BitArray>();

            var maskRegex = new Regex(@"mask\ \=\ (?<Mask>.*)");
            var memRegex = new Regex(@"mem\[(?<Address>.*?)\]\ \=\ (?<Value>.*)");

            foreach (var instruction in input)
            {
                var maskResult = maskRegex.Match(instruction);
                if (maskResult.Success)
                {
                    var mask = new string(maskResult.Groups["Mask"].Value.Reverse().ToArray());
                    zeroMask.SetAll(true);
                    oneMask.SetAll(false);
                    
                    foreach (var oneIndex in mask.AllIndexesOf("1"))
                    {
                        oneMask.Set(oneIndex, true);
                    }

                    foreach (var zeroIndex in mask.AllIndexesOf("0"))
                    {
                        zeroMask.Set(zeroIndex, false);
                    }
                }

                var memResult = memRegex.Match(instruction);
                if (memResult.Success)
                {
                    var address = memResult.Groups["Address"].Value;
                    var value = memResult.Groups["Value"].Value;
                    var bytes = BitConverter.GetBytes(int.Parse(value));
                    var valueBitArray = new BitArray(bytes)
                    {
                        Length = 36
                    };

                    valueBitArray.Or(oneMask);
                    valueBitArray.And(zeroMask);

                    memoryAddresses[int.Parse(address)] = valueBitArray;
                }
            }

            ulong sum = 0;

            foreach (var value in memoryAddresses.Values)
            {
                var longArray = new uint[2];
                value.CopyTo(longArray, 0);

                sum += longArray[0] + ((ulong)longArray[1] << 32);
            }

            return sum;
        }


    }


}
