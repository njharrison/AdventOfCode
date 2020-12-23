using AdventOfCode.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day22
{
    class Task1 : Day22TaskBase, ITask
    {
        public string Solve(string[] input)
        {
            List<Queue<int>> players = ParseInput(input);

            while (players.All(a => a.Any()))
            {
                var allCards = players.Select(a => a.Dequeue()).ToList();
                var max = allCards.Max();
                var index = allCards.IndexOf(max);

                foreach (var item in allCards.OrderByDescending(a => a))
                {
                    players[index].Enqueue(item);
                }
            }

            var winningPlayer = players.First(a => a.Count > 0).ToList();
            int result = GetWinningScore(winningPlayer);
            return result.ToString();
        }
    }
}
