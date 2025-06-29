namespace Session.Polymorphism
{
    //class TypeA
    //{
    //    public int A { get; set; }
    //    public void print()
    //    {
    //        Console.WriteLine($"TypeA: {A}");
    //    }
    //}
    //class TypeB : TypeA
    //{
    //    public int B { get; set; }
    //    public new void print()
    //    {
    //        Console.WriteLine($"TypeB: {B}");
    //    }
    //}

    class TypeA
    {
        public int A { get; set; }
        public virtual void print()
        {
            Console.WriteLine($"TypeA: {A}");
        }
    }
    class TypeB : TypeA
    {
        public int B { get; set; }
        public override void print()
        {
            Console.WriteLine($"TypeB: {B}");
        }
    }
}
