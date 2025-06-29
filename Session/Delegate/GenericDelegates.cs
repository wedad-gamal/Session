namespace Session.Delegate
{
    // out TResult means TResult is covariant and can be used as a return type
    //public delegate T MathOperation<T, out TResult>(T a, T b);

    class GenericCalculator
    {
        public static void Calculate<T, TResult>(T a, T b, Func<T, T, T> mathOperation)
        {
            T result = mathOperation(a, b);
            Console.WriteLine(result);
        }

        //public static T Add<T>(T a, T b) where T : struct, IAdditionOperators<T, T, T>
        //{
        //    return a + b;
        //}

        //public static int Subtract(int a, int b)
        //{
        //    return a - b;
        //}

        //public static int Multiply(int a, int b)
        //{
        //    return a * b;
        //}

        //public static int Divide(int a, int b)
        //{
        //    return a / b;
        //}
    }
}
