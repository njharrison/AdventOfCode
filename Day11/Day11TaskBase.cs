using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day11
{
    abstract internal class Day11TaskBase
    {
        protected const char occupiedSeat = '#';
        protected const char unoccupiedSeat = 'L';
        protected const char floor = '.';

        public string Solve(string[] input)
        {
            char[,] seatArray = this.ReadInput(input);
            char[,] lastSeatArray;
            do
            {
                //WriteSeatArray(seatArray);
                lastSeatArray = seatArray;
                seatArray = ApplySeatingRules(lastSeatArray);
            }
            while (!this.AreEqual(lastSeatArray, seatArray));

            return this.CountOccurencesOf(seatArray, occupiedSeat).ToString();
        }

#pragma warning disable IDE0051 // Remove unused private members - used for debugging
        private void WriteSeatArray(char[,] seatArray)
#pragma warning restore IDE0051 // Remove unused private members
        {
            for (var i = 0; i < seatArray.GetLength(1); i++)
            {
                for (var j = 0; j < seatArray.GetLength(0); j++)
                {
                    Console.Write(seatArray[j, i]);
                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        private char[,] ApplySeatingRules(char[,] input)
        {
            var result = this.Clone(input);
            for (var i = 0; i < result.GetLength(0); i++)
            {
                for (var j = 0; j < result.GetLength(1); j++)
                {
                    ApplySeatingRules(input, ref result, i, j);
                }
            }

            return result;
        }

        protected char[,] ReadInput(string[] input)
        {
            var width = input[0].Length;
            var height = input.Length;

            var result = new char[width, height];

            for (var i = 0; i < height; i++)
            {
                for (var j = 0; j < width; j++)
                {
                    result[j, i] = input[i][j];
                }
            }

            return result;
        }

        protected char[,] Clone(char[,] input)
        {
            var result = new char[input.GetLength(0), input.GetLength(1)];

            for (var i = 0; i < input.GetLength(0); i++)
            {
                for (var j = 0; j < input.GetLength(1); j++)
                {
                    result[i, j] = input[i, j];
                }
            }

            return result;
        }

        protected bool AreEqual(char[,] input1, char[,] input2)
        {
            for (var i = 0; i < input1.GetLength(0); i++)
            {
                for (var j = 0; j < input1.GetLength(1); j++)
                {
                    if (input1[i, j] != input2[i, j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        protected ulong CountOccurencesOf(char[,] input, char testValue)
        {
            ulong count = 0;

            for (var i = 0; i < input.GetLength(0); i++)
            {
                for (var j = 0; j < input.GetLength(1); j++)
                {
                    if (input[i, j] == testValue)
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        protected abstract void ApplySeatingRules(char[,] input, ref char[,] result, int centreX, int centreY);
    }
}