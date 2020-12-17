using System;

namespace AdventOfCode.Day17
{
    internal class Point4D
    {
        public Point4D(int x, int y, int z, int w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
            UniqueIdentifier = (long)W * short.MaxValue * short.MaxValue * short.MaxValue +
                               (long)X * short.MaxValue * short.MaxValue + 
                               (long)Y * short.MaxValue + 
                               (long)Z;
        }

        public int X { get; }

        public int Y { get; }

        public int Z { get; }

        public int W { get; }

        public long UniqueIdentifier { get; }

        public bool IsAdjacent(Point4D other)
        {
            return (Math.Abs(this.X - other.X) <= 1
                || Math.Abs(this.Y - other.Y) <= 1
                || Math.Abs(this.Z - other.Z) <= 1
                || Math.Abs(this.W - other.W) <= 1
                && !this.Equals(other));
        }

        public override bool Equals(object objUnknown)
        {
            return objUnknown is Point4D obj && obj.X == this.X && obj.Y == this.Y && obj.Z == this.Z && obj.W == this.W;
        }

        public override int GetHashCode()
        {
            return (int)this.UniqueIdentifier;
        }
    }
}