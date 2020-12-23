using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day23
{
    abstract internal class Day23TaskBase
    {
        protected void PlayGame(List<int> cups, int iterations)
        {
            var stopWatch = new Stopwatch();
            var minCup = cups.Min();
            var maxCup = cups.Max();
            stopWatch.Start();
            var cupNumber = 0;

            var pickedUpCups = new int[3];
            for (var i = 0; i < iterations; i++)
            {
                cupNumber %= cups.Count;
                var cup = cups[cupNumber];
                //Console.WriteLine(cup);
                var cupId = cup;

                for (var j = 0; j < 3; j++)
                {
                    var pickUpCupNumber = (cupNumber + 1);
                    if (pickUpCupNumber >= cups.Count)
                    {
                        pickUpCupNumber = 0;
                        cupNumber--;
                    }

                    pickedUpCups[j] = cups[pickUpCupNumber];
                    cups.RemoveAt(pickUpCupNumber);
                }

                cupId--;
                if (cupId < minCup)
                {
                    cupId = maxCup;
                }

                while (pickedUpCups.Contains(cupId))
                {
                    cupId--;
                    if (cupId < minCup)
                    {
                        cupId = maxCup;
                    }
                }

                var cupIndex = cups.IndexOf(cupId);

                foreach (var insertCup in pickedUpCups.Reverse<int>())
                {
                    cups.Insert(cupIndex + 1, insertCup);
                }

                if (cupIndex + 1 <= cupNumber)
                {
                    cupNumber += 4;
                }
                else
                {
                    cupNumber += 1;
                }

                //if (cupNumber != (cups.IndexOf(cup) + 1))
                //{
                //    Console.WriteLine("WHAT");
                //}

                //Console.WriteLine(cups.Aggregate(string.Empty, (a, b) => a + b.ToString()));

                if (i % 10000 == 0 && i > 0)
                {
                    var elapsed = stopWatch.Elapsed;
                    Console.WriteLine((stopWatch.Elapsed / i) * iterations - stopWatch.Elapsed);
                }
            }
        }

        protected List<int> PlayGameLinkedList(List<int> cups, int iterations)
        {
            var list = new LinkedList<int>(cups);
            var cupDictionary = new LinkedListNode<int>[list.Count];

            var cupNode = list.First;
            while (cupNode != null)
            {
                cupDictionary[cupNode.Value - 1] = cupNode;
                cupNode = cupNode.Next;
            }

            var minCup = cups.Min();
            var maxCup = cups.Max();

            LinkedListNode<int> currentItem = list.First;

            var removedItems = new LinkedListNode<int>[3];

            for (var i = 0; i < iterations; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    if (currentItem.Next != null)
                    {
                        removedItems[j] = currentItem.Next;
                        list.Remove(currentItem.Next);
                    }
                    else
                    {
                        removedItems[j] = list.First;
                        list.Remove(list.First);
                    }
                }

                var requiredValue = currentItem.Value - 1;

                if (requiredValue < minCup)
                {
                    requiredValue = maxCup;
                }

                while (removedItems.Any(a => a.Value == requiredValue))
                {
                    requiredValue--;
                    if (requiredValue < minCup)
                    {
                        requiredValue = maxCup;
                    }
                }

                var insertNode = cupDictionary[requiredValue - 1];

                foreach (var value in removedItems)
                {
                    list.AddAfter(insertNode, value);
                    insertNode = value;
                }

                currentItem = currentItem.Next;

                if (currentItem == null)
                {
                    currentItem = list.First;
                }
            }

            return list.ToList();
        }
    }
}