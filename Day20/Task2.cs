using AdventOfCode.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day20
{
    class Task2 : Day20TaskBase, ITask
    {
        public ulong Solve(string[] input)
        {
            var tiles = this.ParseInputs(input);

            List<Tile> cornerMatches = FindCorners(tiles);
            var tileArray = GetTileArray(tiles, cornerMatches);

            var fullMap = new List<string>(new string[tileArray.GetLength(1) * (tileArray[0, 0].Description.Count - 2)]);
            
            for (var i = 0; i < tileArray.GetLength(0); i++)
            {
                for (var i1 = 1; i1 < tileArray[0, 0].Description.Count - 1; i1++)
                {
                    var combined = string.Empty;

                    for (var j = 0; j < tileArray.GetLength(1); j++)
                    {
                        combined = combined + tileArray[j, i].Description[i1].Substring(1, tileArray[j, i].Description[i1].Length - 2);
                    }

                    fullMap[i * (tileArray[0, 0].Description.Count - 2) + i1 - 1] = combined;
                }
            }


            var patternMatch = new PatternMatch();

            return (ulong)patternMatch.MaxPatternMatches(fullMap);
        }

        private Tile[,] GetTileArray(List<Tile> tiles, List<Tile> cornerMatches)
        {
            var dimension = (int)Math.Sqrt(tiles.Count);
            var tileArray = new Tile[dimension, dimension];

            tileArray[0, 0] = cornerMatches[0];

            tiles.Remove(tileArray[0, 0]);

            for (var rotation = 0; rotation < 4; rotation++)
            {
                var matches = new Tile[2];
                foreach (var tile in tiles)
                {
                    if (tile == tileArray[0, 0])
                    {
                        continue;
                    }

                    if (tile.UpSides.Any(a => this.SidesMatch(a, tileArray[0, 0].UpSides[1])
                        || tile.DownSides.Any(a => this.SidesMatch(a, tileArray[0, 0].UpSides[1]))))
                    {
                        matches[0] = tile;
                    }

                    if (tile.UpSides.Any(a => this.SidesMatch(a, tileArray[0, 0].UpSides[2])
                        || tile.DownSides.Any(a => this.SidesMatch(a, tileArray[0, 0].UpSides[2]))))
                    {
                        matches[1] = tile;
                    }
                }

                if (matches[0] != null && matches[1] != null)
                {
                    break;
                }

                tileArray[0, 0].Rotate();
            }

            for (var y = 0; y < tileArray.GetLength(0); y++)
            {
                for (var x = 0; x < tileArray.GetLength(1); x++)
                {
                    if (x == 0 && y == 0)
                    {
                        continue;
                    }

                    if (x != 0)
                    {
                        var previousTile = tileArray[x - 1, y];

                        var newTile = tiles.FirstOrDefault(a => a.UpSides.Any(b => SidesMatch(b, previousTile.UpSides[1])));

                        if (newTile == null)
                        {
                            newTile = tiles.First(a => a.DownSides.Any(b => SidesMatch(b, previousTile.UpSides[1])));
                            newTile.Flip();
                        }

                        for (var rotation = 0; rotation < 4; rotation++)
                        {
                            if (SidesMatch(newTile.UpSides[3], previousTile.UpSides[1]))
                            {
                                tileArray[x, y] = newTile;
                                tiles.Remove(newTile);
                                break;
                            }

                            newTile.Rotate();
                        }
                    }
                    else
                    {
                        var previousTile = tileArray[x, y - 1];

                        var newTile = tiles.FirstOrDefault(a => a.UpSides.Any(b => SidesMatch(b, previousTile.UpSides[2])));

                        if (newTile == null)
                        {
                            newTile = tiles.First(a => a.DownSides.Any(b => SidesMatch(b, previousTile.UpSides[2])));
                            newTile.Flip();
                        }

                        for (var rotation = 0; rotation < 4; rotation++)
                        {
                            if (SidesMatch(newTile.UpSides[0], previousTile.UpSides[2]))
                            {
                                tileArray[x, y] = newTile;
                                tiles.Remove(newTile);
                                break;
                            }

                            newTile.Rotate();
                        }
                    }

                }
            }

            return tileArray;
        }
    }
}
