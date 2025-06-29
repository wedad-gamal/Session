namespace Session.Inheritance
{
    class Child : Parent
    {
        public Child(int x, int y, int z) : base(x, y)
        {
            Z = z;
        }
        public int Z { get; set; }
    }
}
