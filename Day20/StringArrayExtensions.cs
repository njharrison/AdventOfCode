using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day20
{
    public static class StringArrayExtensions
    {
        public static List<string> ReverseAll(this IEnumerable<string> input)
        {
            return input.Select(a => new string(a.Reverse().ToArray())).ToList();
        }

        public static List<string> Rotate(this IEnumerable<string> input)
        {
            var newArray = new List<string>();

            for (var i = 0; i < input.First().Length; i++)
            {
                var newString = new string(input.Select(a => a[i]).Reverse().ToArray());
                newArray.Add(newString);
            }

            return newArray;
        }
    }
}
