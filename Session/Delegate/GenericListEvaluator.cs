namespace Session.Delegate
{
    public delegate bool FilterDelegate<T>(T item);
    public class GenericListEvaluator
    {
        public static List<T> GetNumbers<T>(List<T> numbers, FilterDelegate<T> dlg)
        {
            List<T> result = new List<T>();
            foreach (T item in numbers)
            {
                if (dlg(item))
                    result.Add(item);
            }
            return result;
        }

        // Updated Even method to restrict T to numeric types
        public static bool Even<T>(T item) where T : struct, IConvertible
        {
            if (!typeof(T).IsPrimitive || typeof(T) == typeof(bool) || typeof(T) == typeof(char))
                throw new InvalidOperationException("Even method only supports numeric types.");

            return Convert.ToInt32(item) % 2 == 0;
        }

        public static bool Odd<T>(T item) where T : struct, IConvertible
        {
            if (!typeof(T).IsPrimitive || typeof(T) == typeof(bool) || typeof(T) == typeof(char))
                throw new InvalidOperationException("Odd method only supports numeric types.");

            return Convert.ToInt32(item) % 2 != 0;
        }
        public static void Print(List<int> list)
        {
            foreach (var item in list)
                Console.Write($"{item},");
            Console.WriteLine();
        }
    }
}
