namespace Session.Delegate
{
    public delegate bool FilterDelegate(int item);
    public class ListEvaluator
    {
        public static List<int> GetNumbers(List<int> numbers, FilterDelegate dlg)
        {
            List<int> result = new List<int>();
            foreach (int item in numbers)
            {
                if (dlg(item))
                    result.Add(item);
            }
            return result;
        }

        public static bool Even(int item)
        {
            return item % 2 == 0;
        }

        public static bool Odd(int item)
        {
            return item % 2 != 0;
        }
        public static void Print(List<int> list)
        {
            foreach (var item in list)
                Console.Write($"{item},");
            Console.WriteLine();
        }
    }
}
