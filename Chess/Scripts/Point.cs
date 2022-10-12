using System;

namespace Chess.Scripts
{
	public class Point : ICloneable
	{
		public int X;
		public int Y;
		public Point (int x, int y)
		{
			X = x;
			Y = y;
		}

		protected bool Equals (Point other)
		{
			return X == other.X && Y == other.Y;
		}
		public override bool Equals (object obj)
		{
			if (ReferenceEquals (null, obj))
				return false;
			if (ReferenceEquals (this, obj))
				return true;
			if (obj.GetType () != this.GetType ())
				return false;
			return Equals ((Point)obj);
		}
		public override int GetHashCode ()
		{
			unchecked
			{
				return (X * 397) ^ Y;
			}
		}

		public object Clone()
		{
			return new Point(X, Y);
		}


		public static bool operator == (Point p1, Point p2)
		{
			return p1 != null && p1.Equals (p2);
		}
		public static bool operator != (Point p1, Point p2)
		{
			return !(p1 == p2);
		}


		public static Point operator + (Point p1, Point p2)
		{
			return new Point(p1.X + p2.X, p1.Y + p2.Y);
		}

		public static Point operator - (Point p1, Point p2)
		{
			return new Point(p1.X - p2.X, p1.Y - p2.Y);
		}

		public override string ToString()
		{
			return $"{X}:{Y}";
		}
	}
}