namespace Session.Delegate
{
    public delegate int MathOperation(int a, int b);
    class Calculator
    {
        public static void calculate(int a, int b, MathOperation mathOperation)
        {
            Console.WriteLine(mathOperation(a, b));
            //or use invoke method
            //Console.WriteLine(mathOperation.Invoke(a, b));
        }

        public static int Add(int a, int b)
        {
            return a + b;
        }
        public static int Subtract(int a, int b)
        {
            return a - b;
        }
        public static int Multiply(int a, int b)
        {
            return a * b;
        }
        public static int Divide(int a, int b) => a / b;



    }
}
