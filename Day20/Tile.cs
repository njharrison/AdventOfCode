using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day20
{
    internal class Tile
    {
        IEnumerable<bool>[] upSides = new IEnumerable<bool>[4];

        IEnumerable<bool>[] downSides = new IEnumerable<bool>[4];
        private int key;
        private List<string> description;

        public Tile(int key, List<string> description)
        {
            this.Key = key;
            this.SetDescription(description);
        }

        private void SetDescription(List<string> description)
        {
            this.description = description;

            var top = description[0].Select(a => a == '#');
            var bottom = description[description.Count - 1].Select(a => a == '#');
            var left = description.Select(a => a[0]).Select(a => a == '#');
            var right = description.Select(a => a[a.Length - 1]).Select(a => a == '#');

            UpSides[0] = top;
            UpSides[1] = right;
            UpSides[2] = bottom.Reverse();
            UpSides[3] = left.Reverse();

            DownSides[0] = top.Reverse();
            DownSides[1] = left;
            DownSides[2] = bottom;
            DownSides[3] = right.Reverse();
        }

        public int Key { get => key; set => key = value; }
        public IEnumerable<bool>[] DownSides { get => downSides; set => downSides = value; }
        public IEnumerable<bool>[] UpSides { get => upSides; set => upSides = value; }
        
        public List<string> Description { get => description; }

        public void Flip()
        {
            this.SetDescription(this.description.ReverseAll());
        }

        public void Rotate()
        {
            this.SetDescription(this.description.Rotate());
        }
    }
}