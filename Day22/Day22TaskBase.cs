using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day22
{
    abstract internal class Day22TaskBase
    {
        protected static List<Queue<int>> ParseInput(string[] input)
        {
            var players = new List<Queue<int>>();
            var player = new Queue<int>();

            foreach (var line in input)
            {
                if (line.Contains("Player "))
                {
                    var newLine = line.Replace("Player ", string.Empty);
                    newLine = newLine.Replace(":", string.Empty);
                    player = new Queue<int>();
                    players.Add(player);
                }
                else if (line != string.Empty)
                {
                    player.Enqueue(int.Parse(line));
                }
            }

            return players;
        }


        protected int GetWinningScore(List<int> winningPlayer)
        {
            var result = 0;
            for (var i = 0; i < winningPlayer.Count; i++)
            {
                result += winningPlayer[i] * (winningPlayer.Count - i);
            }

            return result;
        }
    }
}