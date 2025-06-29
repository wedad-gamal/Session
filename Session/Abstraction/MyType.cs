namespace Session.Abstraction
{
    class MyType : IMyType
    {
        int IMyType.Salary { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        void IMyType.print()
        {
            throw new NotImplementedException();
        }
    }
}
