namespace Session.Abstraction
{
    abstract class Shape
    {
        public abstract int Dimension1 { get; set; }
        public abstract int Dimension2 { get; set; }
        public int area { get; set; }

        public abstract void calculateArea();
    }

    class Rectangle : Shape
    {
        public override int Dimension1 { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override int Dimension2 { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void calculateArea()
        {
            throw new NotImplementedException();
        }
    }
}
