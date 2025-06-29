namespace Session.PassByReference
{
    public class Point2D
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Point2D() { }

        public Point2D(int x, int y) { X = x; Y = y; }

        public override string ToString()
        {
            return $"{X}, {Y}";
        }

        public static void Swap(ref Point2D point1, ref Point2D point2)
        {
            (point1, point2) = (point2, point1);
        }
    }
}
