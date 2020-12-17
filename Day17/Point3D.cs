using System;

namespace AdventOfCode.Day17
{
    internal class Point3D
    {
        public Point3D(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
            UniqueIdentifier = (long)X * short.MaxValue * short.MaxValue + (long)Y * short.MaxValue + (long)Z;
        }

        public int X { get; }

        public int Y { get; }

        public int Z { get; }

        public long UniqueIdentifier { get; }

        public bool IsAdjacent(Point3D other)
        {
            return (Math.Abs(this.X - other.X) <= 1
                || Math.Abs(this.Y - other.Y) <= 1
                || Math.Abs(this.Z - other.Z) <= 1
                && !this.Equals(other));
        }

        public override bool Equals(object objUnknown)
        {
            return objUnknown is Point3D obj && obj.X == this.X && obj.Y == this.Y && obj.Z == this.Z;
        }

        public override int GetHashCode()
        {
            return (int)this.UniqueIdentifier;
        }
    }
}