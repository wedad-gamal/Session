namespace Session.Abstraction
{
    interface IMyType
    {
        void print();

        public int Salary { get; set; }

        //public int age;// not valid

        public void print2()
        {
            Console.WriteLine("print2");
        }

        private void print3()
        {
            Console.WriteLine("print2");
        }
    }
}
