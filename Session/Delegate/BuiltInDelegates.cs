namespace Session.Delegate
{
    public class BuiltInDelegates
    {
        public static T Example1<T>(Func<T> func)
        {
            return func();
        }

        public static void Example2(Action action)
        {
            action();
        }

        public static void Example3(Predicate<int> predicate, int number)
        {
            if (predicate(number))
            {
                Console.WriteLine($"{number} is even");
            }
            else
            {
                Console.WriteLine($"{number} is odd");
            }
        }
    }
}
