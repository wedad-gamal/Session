namespace Session.Inheritance
{
    class Parent
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Parent()
        {

        }
        public Parent(int x)
        {
            X = x;
        }
        public Parent(int x, int y) : this(x)
        {
            Y = y;
        }
        public void Print()
        {
            Console.WriteLine($"X: {X}, Y: {Y}");
        }
    }
}
