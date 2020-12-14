using AdventOfCode.Library;
using AdventOfCode.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day14
{
    class Task2 : Day14TaskBase, ITask
    {
        public ulong Solve(string[] input)
        {
            var oneMask = new BitArray(36);
            var floatingIndices = new List<int>();

            var memoryAddresses = new Dictionary<ulong, ulong>();

            var maskRegex = new Regex(@"mask\ \=\ (?<Mask>.*)");
            var memRegex = new Regex(@"mem\[(?<Address>.*?)\]\ \=\ (?<Value>.*)");

            foreach (var instruction in input)
            {
                var maskResult = maskRegex.Match(instruction);
                if (maskResult.Success)
                {
                    var mask = new string(maskResult.Groups["Mask"].Value.Reverse().ToArray());
                    oneMask.SetAll(false);

                    foreach (var oneIndex in mask.AllIndexesOf("1"))
                    {
                        oneMask.Set(oneIndex, true);
                    }

                    floatingIndices = mask.AllIndexesOf("X").ToList();
                }

                var memResult = memRegex.Match(instruction);
                if (memResult.Success)
                {
                    var address = memResult.Groups["Address"].Value;
                    var value = ulong.Parse(memResult.Groups["Value"].Value);
                    var bytes = BitConverter.GetBytes(int.Parse(address));
                    var addressBitArray = new BitArray(bytes)
                    {
                        Length = 36
                    };

                    addressBitArray.Or(oneMask);

                    AddAllCombinations(addressBitArray, memoryAddresses, value, floatingIndices);
                }
            }

            ulong sum = 0;

            foreach (var value in memoryAddresses.Values)
            {
                sum += value;
            }

            return sum;
        }

        private static ulong ConvertToLong(BitArray value)
        {
            var longArray = new uint[2];
            value.CopyTo(longArray, 0);

            return longArray[0] + ((ulong)longArray[1] << 32);
        }

        private void AddAllCombinations(BitArray address, Dictionary<ulong, ulong> memorySpace, ulong currentValue, IEnumerable<int> floatingIndices)
        {
            if (!floatingIndices.Any())
            {
                memorySpace[ConvertToLong(address)] = currentValue;
                return;
            }

            var index = floatingIndices.First();
            var onValue = new BitArray(address);
            onValue[index] = true;
            AddAllCombinations(onValue, memorySpace, currentValue, floatingIndices.Skip(1));

            var offValue = new BitArray(address);
            offValue[index] = false;
            AddAllCombinations(offValue, memorySpace, currentValue, floatingIndices.Skip(1));
        }
    }
}
