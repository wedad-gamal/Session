namespace Session
{
    class Engine
    {
        public void Start()
        {
            Console.WriteLine("Started");
        }
    }
    class Car
    {
        private Engine Engine;
        public Car()
        {
            Engine = new Engine();
        }
        public void Start()
        {
            Engine.Start();
        }
    }
}
