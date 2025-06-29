
namespace Session.Generics
{
    public class Point2D : IComparable, IComparable<Point2D>
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Point2D()
        {
        }

        public Point2D(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"{X}, {Y}";
        }

        public static void Swap(ref Point2D point1, ref Point2D point2)
        {
            (point1, point2) = (point2, point1);
        }

        public override bool Equals(object? obj)
        {
            return obj is Point2D d &&
                   X == d.X &&
                   Y == d.Y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        public int CompareTo(object? obj)
        {
            if (obj is Point2D point)
            {
                if (X == point.X)
                    return Y.CompareTo(point.Y);
                return X.CompareTo(point.X);
            }
            throw new ArgumentException("Object is not a Point2D");
        }

        public int CompareTo(Point2D? other)
        {
            // with out headache of boxing and unboxing in casting
            if (other is not null)
            {
                if (X == other.X)
                    return Y.CompareTo(other.Y);
                return X.CompareTo(other.X);
            }
            throw new NullReferenceException();
        }
    }

}
