using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day20
{
    abstract internal class Day20TaskBase
    {
        protected List<Tile> ParseInputs(string[] input)
        {
            var tileTitleRegex = new Regex(@"Tile (?<TileId>\d+)\:");

            var tiles = new Dictionary<int, List<string>>();

            var currentTileIdentifier = 0;

            var currentList = new List<string>();

            foreach (var line in input)
            {
                var match = tileTitleRegex.Match(line);

                if (match.Success)
                {
                    currentTileIdentifier = int.Parse(match.Groups["TileId"].Value);
                }
                else if (line != string.Empty)
                {
                    currentList.Add(line);
                }
                else
                {
                    tiles.Add(currentTileIdentifier, currentList);
                    currentList = new List<string>();
                }
            }

            tiles.Add(currentTileIdentifier, currentList);

            var returnTiles = new List<Tile>();

            foreach (var key in tiles.Keys)
            {
                returnTiles.Add(new Tile(key, tiles[key]));
            }

            return returnTiles;
        }

        protected bool SidesMatch(IEnumerable<bool> side1, IEnumerable<bool> side2)
        {
            return side1.Zip(side2.Reverse(), (a, b) => a == b).All(a => a);
        }

        protected List<Tile> FindCorners(List<Tile> tiles)
        {
            var cornerMatches = new List<Tile>();

            foreach (var tile1 in tiles)
            {
                int maxMatches = FindMatchCount(tiles, tile1);

                if (maxMatches == 2)
                {
                    cornerMatches.Add(tile1);
                }
            }

            return cornerMatches;
        }

        private int FindMatchCount(List<Tile> tiles, Tile tile1)
        {
            var upMatches = 0;

            foreach (var side in tile1.UpSides)
            {
                foreach (var tile2 in tiles)
                {
                    if (tile1 == tile2)
                    {
                        continue;
                    }

                    if (tile2.UpSides.Any(a => this.SidesMatch(a, side)) || tile2.DownSides.Any(a => this.SidesMatch(a, side)))
                    {
                        upMatches++;
                    }

                }
            }

            var downMatches = 0;

            foreach (var side in tile1.DownSides)
            {
                foreach (var tile2 in tiles)
                {
                    if (tile1 == tile2)
                    {
                        continue;
                    }

                    if (tile2.UpSides.Any(a => this.SidesMatch(a, side)) || tile2.DownSides.Any(a => this.SidesMatch(a, side)))
                    {
                        downMatches++;
                    }
                }
            }

            var maxMatches = Math.Max(upMatches, downMatches);
            return maxMatches;
        }
    }
}