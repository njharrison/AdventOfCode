using AdventOfCode.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day22
{
    class Task2 : Day22TaskBase, ITask
    {
        readonly Dictionary<List<Queue<int>>, Tuple<int, bool, List<Queue<int>>>> previousRounds = new Dictionary<List<Queue<int>>, Tuple<int, bool, List<Queue<int>>>>();

        public string Solve(string[] input)
        {
            List<Queue<int>> players = ParseInput(input);

            var result = RecursiveCombat(players, 0);

            return GetWinningScore(result.Item3[result.Item1].ToList()).ToString();
        }

        private Tuple<int, bool, List<Queue<int>>> RecursiveCombat(List<Queue<int>> originalPlayers, int level)
        {
            List<Queue<int>> players = new List<Queue<int>>();

            var subTask = new Task2();

            while (originalPlayers.Any() && originalPlayers.All(a => a.Any()))
            {
                if (RoundExists(originalPlayers))
                {
                    return new Tuple<int, bool, List<Queue<int>>>(0, true, previousRounds.First(a => RoundExists(originalPlayers)).Value.Item3);
                }
                else
                {
                    Tuple<int, bool, List<Queue<int>>> result;

                    players = ClonePlayers(originalPlayers);

                    var topCards = players.Select(a => a.Dequeue()).ToList();

                    if (players.Zip(topCards, (a, b) => a.Count >= b).All(a => a))
                    {
                        var recursiveResult = subTask.RecursiveCombat(players.Zip(topCards, (a, b) => new Queue<int>(a.Take(b))).ToList(), level++);

                        players[recursiveResult.Item1].Enqueue(topCards[recursiveResult.Item1]);
                        topCards.RemoveAt(recursiveResult.Item1);
                        foreach (var card in topCards)
                        {
                            players[recursiveResult.Item1].Enqueue(card);
                        }

                        result = new Tuple<int, bool, List<Queue<int>>>(recursiveResult.Item1, false, players);
                    }
                    else
                    {
                        var max = topCards.Max();
                        var index = topCards.IndexOf(max);

                        foreach (var item in topCards.OrderByDescending(a => a))
                        {
                            players[index].Enqueue(item);
                        }

                        result = new Tuple<int, bool, List<Queue<int>>>(index, false, players);
                    }

                    previousRounds.Add(originalPlayers, result);
                }
                

                originalPlayers = players;
            }

            int winningPlayer = 0;
            for (var i = 0; i < players.Count; i++)
            {
                if (players[i].Any())
                {
                    winningPlayer = i;
                    break;
                }
            }

            return new Tuple<int, bool, List<Queue<int>>>(winningPlayer, false, players);
        }

        private List<Queue<int>> ClonePlayers(List<Queue<int>> players)
        {
            return players.Select(a => new Queue<int>(a)).ToList();
        }

        private bool RoundExists(List<Queue<int>> players)
        {
            return previousRounds.Any(round =>
            {
                return PlayerEqual(players, round.Key);
            });
        }

        private static bool PlayerEqual(List<Queue<int>> players, List<Queue<int>> round)
        {
            return round.Zip(players, (a, b) =>
            {
                if (a.Count == b.Count)
                {
                    return a.Zip(b, (c, d) => c == d).All(e => e);
                }
                return false;
            }).All(f => f);
        }
    }
}
