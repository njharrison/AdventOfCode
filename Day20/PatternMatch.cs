using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day20
{
    class PatternMatch
    {
        string[] pattern = new string[3];

        int startsFirst = 1;
        int endsLast = 1;

        public PatternMatch()
        {
            pattern[0] = "                  # ";
            pattern[1] = "#    ##    ##    ###";
            pattern[2] = " #  #  #  #  #  #   ";
        }

        public int MaxPatternMatches(List<string> source)
        {
            var maxMatches = 0;
            for (var i = 0; i < 4; i++)
            {
                var newMatch = this.CountOfPattern(source.ToList());

                if (newMatch > maxMatches)
                {
                    maxMatches = newMatch;
                }

                source = source.Rotate();
            }

            source = source.ReverseAll();
            for (var i = 0; i < 4; i++)
            {
                var newMatch = this.CountOfPattern(source.ToList());

                if (newMatch < maxMatches)
                {
                    maxMatches = newMatch;
                }

                source = source.Rotate();
            }

            return maxMatches;
        }

        public int CountOfPattern(List<string> source)
        {
            var countOfPattern = 0;

            for (var y = 0; y < source.Count - pattern.Length + startsFirst; y++)
            {
                for (var x = 0; x < source[y].Length - pattern[endsLast].Length; x++)
                {
                    if (source[y + startsFirst][x] == '#')
                    {
                        var mightExist = true;
                        for (var i = 0; i < pattern.Length; i++)
                        {
                            for (var j = 0; j < pattern[i].Length; j++)
                            {
                                if (pattern[i][j] == '#' && source[y + i][x + j] != '#' && source[y + i][x + j] != 'O')
                                {
                                    mightExist = false;
                                    break;
                                }
                            }

                            if (!mightExist)
                            {
                                break;
                            }
                        }

                        if (mightExist)
                        {
                            SetPatternToMarkings(pattern, x, y, source);
                        }
                    }
                }
            }

            return source.Aggregate(0, (a, b) => a + b.Count(c => c == '#'));
        }

        private void SetPatternToMarkings(string[] pattern, int x, int y, List<string> source)
        {
            for (var i = 0; i < pattern.Length; i++)
            {
                var tempChar = source[y + i].ToArray();
                for (var j = 0; j < pattern[i].Length; j++)
                {
                    if (pattern[i][j] == '#')
                    {
                        tempChar[x + j] = 'O';
                    }
                }

                source[y + i] = new string(tempChar);
            }
        }
    }
}
