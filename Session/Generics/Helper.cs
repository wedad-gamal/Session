namespace Session.Generics
{

    /*
     * Generic Contraints:
     * 1. Primary Contraints {0,1}
     *   1.1 class => where T : class => means T of type reference type
     *   1.2 struct => where T : struct => means T of type value type
     *    struct means compiler will generate parameterless constructor 
     *      T x = new T(); // this will not work for class only for struct
     *    class means compiler will not generate parameterless constructor incase parameterized constructor
     *    
     *   Note:can not use class and struct at the same time
     *   
     * 2. Special Primary Contraints      
     *      where T: <base class> => T must be derived from base class
     *     
     * 3. Secondary Contraints {0,m}
     *      where T: <interface> => T must implement interface
     *      where T: <base class>, <interface> => T must be derived from base class and implement interface
     *      where T: <interface1>, <interface2> => T must implement both interfaces
     *      where T : <interface1> where T: <interface2> => T must implement interface1 and interface2
     *      where T : <interface1> where T: <base class> => T must be derived from base class and implement interface1
     *      where T : <interface1> where T: <base class>, <interface2> => T must be derived from base class and implement interface1 and interface2
     * 
     * example 
     * public class Helper<T> where T : IComparable
     * T must implement IComparable interface
     * T must have compareTo method
     * T.CompareTo() method must be implemented
     * 
     * 4. Constructor Constraints
     *       where T: new() => T must have parameterless constructor {value type or reference type}
     *       
     *  Note:  
     *      where T: new(), class => T must be reference type and have parameterless constructor
     *      no need to write where T: new(), struct as both have parameterless constructor
     *      must be ordered primary then secondary then constructor  
     *      example where T : class, IComparable, new() // where T : struct, IComparable, new()
     */
    public class Helper<T> where T : IComparable<T>, new()
    {
        public static void Swap(ref T item1, ref T item2)
        {
            (item1, item2) = (item2, item1);
        }

        public static void BubbleSort(T[] array)
        {
            for (int i = 0; i < array?.Length - 1; i++)
            {
                for (int j = 0; j < array?.Length - i - 1; j++)
                {
                    if (array[j].CompareTo(array[j + 1]) > 0)
                    {
                        Swap(ref array[j], ref array[j + 1]);
                    }
                }
            }
        }
    }
}
