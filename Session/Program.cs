using Session.Abstraction;

namespace Session
{
    public record EmployeeRecord(int Id, string Name, decimal Salary = 1000)
    {
        public override string ToString() => $"{Id} {Name} {Salary}";
    }
    public record struct EmployeeRecordStruct(int Id, string Name, decimal Salary)
    {
        public override string ToString() => $"{Id} {Name} {Salary}";
    }

    public record DepartmentRecord()
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public struct Circle
    {
        public int X;
        public int Y;

        public readonly int Sum(int x, int y)
        {
            //X = 2 + x; //Comipler Error can not assign value because it is readonly
            return X + y;
        }
    }
    internal class Program
    {
        public static dynamic Sum(dynamic x, dynamic y) => x + y;

        public static (int, string) GetDetails()
        {
            return (10, "Ahmed");
        }

        public static (int age, string name) GetEnhancedDetails()
        {
            return (age: 10, name: "Ahmed");
        }
        class CustomComparer : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                return x.CompareTo(y);
            }
        }
        static void Main(string[] args)
        {
            #region OOP

            //Child child = new Child() { X = 10, Y = 20 };
            //child.Print(); // Output: X: 10, Y: 20

            //Parent parent = new Child() { X = 30, Y = 40, Z = 10 };
            //child = (Child)parent; // Upcasting

            //child.Print(); // Output: X: 30, Y: 40
            //Console.WriteLine(child.Z); // Output: 10
            //// Console.WriteLine(parent.Z); // This will throw an error because Z is not a member of Parent

            //// Downcasting
            //Parent parent2 = new Parent() { X = 50, Y = 60 };
            ////child = (Child)parent2; // This will throw an InvalidCastException
            ///
            //TypeA typeA = new TypeB() { A = 10, B = 20 };
            //typeA.print(); // output: TypeA: 10 

            //IMyType myType = new MyType();
            //myType.Salary = 1000;
            //myType.print();

            //MyType myType1 = new MyType();
            ////myType1.Salary = 2000;// object can not read explicit implementation only read from interface

            //int[] numbers1 = { 1, 2, 4, 5, 6, 7, 4 };
            //int[] numbers2 = numbers1.Clone() as int[]; // Clone the array

            //Employee employee = new Employee(1, "Ahmed", 2000);
            //Console.WriteLine(employee);
            //Console.WriteLine(employee.GetHashCode());

            //Employee employee2 = employee.Clone() as Employee; // Clone the object
            //Console.WriteLine(employee2);
            //Console.WriteLine(employee2.GetHashCode());

            //int[] numbers1 = { 1, 2, 4, 5, 6, 7, 4 };
            //Array.Sort(numbers1);


            //Employee[] employee = new Employee[3]
            //{
            //    new(){ Id = 1, Name = "Ahmed", Salary = 2000 },
            //    new(){ Id = 2, Name = "Ali", Salary = 1000 },
            //    new(){ Id = 3, Name = "Sara", Salary = 3000 }
            //};

            //Array.Sort(employee);
            //foreach (var emp in employee)
            //{
            //    Console.WriteLine(emp);
            //}

            //Shape shape = new Rectangle();
            ////shape.calculateArea();
            //Employee employee1 = new Employee();
            //Employee employee2 = new Employee();
            //Console.WriteLine(Employee.count);// Output: 2

            ComplexNumber complexNumber1 = new ComplexNumber(12, 2);
            ComplexNumber complexNumber2 = new ComplexNumber(2, 1);

            //ComplexNumber complexNumber3 = complexNumber1 + complexNumber2;
            //Console.WriteLine(complexNumber3);

            //ComplexNumber complexNumber4 = complexNumber1 + 3;
            //Console.WriteLine(complexNumber4);

            //ComplexNumber complexNumber5 = 4 + complexNumber1;
            //Console.WriteLine(complexNumber5);

            //Console.WriteLine(complexNumber1++); //12 + 2i

            //Console.WriteLine(++complexNumber2); //3 + 1i

            //int a = (int)complexNumber1;
            //Console.WriteLine(a); // 12

            //ComplexNumber c1 = 10;
            //Console.WriteLine(c1); //10 + 0i

            //Point2D x = new Point2D(10, 20);
            //Point2D y = new Point2D(30, 40);
            //Console.WriteLine($"x: {x}"); //Output: x: 10, 20
            //Console.WriteLine($"y: {y}"); // Output: y: 30, 40
            //Point2D.Swap(ref x, ref y);

            //Console.WriteLine($"x: {x}"); // Output: x: 30, 40  
            //Console.WriteLine($"y: {y}"); // Output: y: 10, 20
            //int x = 10, y = 20;
            //Helper.Swap<int>(ref x, ref y);
            //Helper.Swap(ref x, ref y);

            //Point2D point1 = new Point2D(10, 20);
            //Point2D point2 = new Point2D(10, 20);
            ////Helper.Swap(ref point1, ref point2);

            ////Helper.Swap<Point2D>(ref point1, ref point2);
            ////Helper<Point2D>.Swap(ref point1, ref point2);
            //Console.WriteLine(point2.Equals(point1));

            //int[] array = { 4, 6, 3, 10, 39, 33, 1, 2 };
            //foreach (var item in array)
            //{
            //    Console.Write(item + " ");
            //}
            //Helper<int>.BubbleSort(array);
            //Console.WriteLine("=======================");
            //foreach (var item in array)
            //{
            //    Console.Write(item + " "); //1 2 3 4 6 10 33 39
            //} 
            #endregion
            #region Generic

            //Point2D[] point2Ds =
            //{
            //    new(10,3),
            //    new(3,5),
            //    new (1,3),
            //    new (1,2),
            //    new(0,6)
            //};
            //Helper<Point2D>.BubbleSort(point2Ds);

            //foreach (var item in point2Ds)
            //{
            //    Console.WriteLine(item);
            //}
            ///*
            // * output:
            // *  0, 6
            //    1, 2
            //    1, 3
            //    3, 5
            //    10, 3
            // */

            #endregion
            #region Casting
            ///*
            //     * implicit casting
            //     */
            //object obj = new Point2D(2, 4);

            ///*
            // * unsafe casting
            // */
            //Point2D point = (Point2D)obj; // will cast if it reference point or its children

            ///*
            // * casting operators {as, is}
            // */
            //Point2D point2 = obj as Point2D; // will not throw exception if casting failed and points to null
            //if (point2 != null)
            //    Console.WriteLine(point2.X);//2

            //object obj2 = 10;
            //int? x = obj2 as int?; // will not throw exception if casting failed and points to null
            //int y = (int)obj2; // will throw exception if casting failed
            ///*
            // * is casting operator will not throw exception if casting failed
            // */
            //if (obj is Point2D point3)
            //{
            //    Console.WriteLine(point3.X);//2
            //}
            //else
            //{
            //    Console.WriteLine("obj is not a Point2D");
            //}
            #endregion
            #region Generic Collections

            //boxing and unboxing
            //when cast employee to object is boxing
            //when cast object to employee is unboxing
            //when cast value type to reference type is boxing
            //when insert cast employee to object and when retrieve casting employee to object

            //ArrayList arrayList = new ArrayList();
            //arrayList.Add(1);
            //arrayList.Add("2");
            //arrayList.AddRange(new int[] { 1, 3, 4 });
            //Console.WriteLine(arrayList[1]);
            //arrayList.TrimToSize();
            //Console.WriteLine(arrayList.Count );
            //Console.WriteLine(arrayList.Capacity);

            //List<int> list = new List<int>();
            //list.Add(1);
            //list.AddRange(new int[] { 1, 2, 3 });
            //list[0] = 1;

            //makes the capacity of the list equal to the number of elements in the list incase 10% of the list is empty
            //list.TrimExcess();
            //remove elements from array with same capacity
            //list.Clear();

            ////increase capacity
            //list.EnsureCapacity(1);
            //Console.WriteLine(list.Count);
            //Console.WriteLine(list.Capacity);

            //takes object that implements interface IComparer
            //list.BinarySearch(2, new CustomComparer());

            //list.Sort(new CustomComparer());

            ////list.GetRange(int index, int count);

            ////list.InsertRange(int index, IEnumerable < T > collection);
            //list.InsertRange(0, new int[] { 1, 2, 3 });

            ////list.Remove(int item);
            //list.Remove(1);

            ////list.RemoveAt(int index);
            //list.RemoveAt(0);

            ////list.Slice(int start, int length)
            //list.Slice(0, 2);

            //list.Reverse();

            //convert to array
            //list.ToArray();

            ////convert to string
            //Console.WriteLine(list.ToString());

            //Hashtable hashtable = new Hashtable();

            //Dictionary<string, long> phoneBook = new();
            //if(!phoneBook.ContainsKey("Ahmed"))
            //{
            //   phoneBook.Add("Ahmed", 123456789);
            //}
            //else
            //{
            //    phoneBook.Add("Ahmed", 123456789);
            //}
            //Console.WriteLine(phoneBook.TryAdd("Mona", 123456789));
            //phoneBook.Add("Ali", 123456789);
            //phoneBook["Ahmed"] = 987654321;

            //Console.WriteLine(phoneBook["Ahmed"]); //987654321

            //phoneBook.TryGetValue("Ali", out long value);
            //Console.WriteLine(value);

            //phoneBook.GetValueOrDefault("Ali");

            //foreach (var item in phoneBook)
            //{
            //    Console.WriteLine($"{item.Key} : {item.Value}"); //Ali : 123456789
            //    //Console.WriteLine(item); //[Ali, 123456789]
            //}

            #endregion
            #region delegates
            //MathOperation mathOperation = new MathOperation(Calculator.Add);
            //MathOperation mathOperation1 = Calculator.Subtract;

            //Calculator.calculate(10, 5, mathOperation);
            //Calculator.calculate(10, 4, Calculator.Add);
            //Calculator.calculate(10, 4, delegate (int x, int y) { return x + y; });
            //Calculator.calculate(10, 4, (x, y) => x + y);





            //GenericCalculator.Calculate<double, double>(10.3, 4.4, GenericCalculator.Add);


            //var numbers = Enumerable.Range(0, 20).ToList();
            //var evenNumbers = ListEvaluator.GetNumbers(numbers, ListEvaluator.Even);
            //Console.WriteLine("Even");
            //ListEvaluator.Print(evenNumbers);

            //var oddNumbers = ListEvaluator.GetNumbers(numbers, ListEvaluator.Odd);
            //Console.WriteLine("Odd");
            //ListEvaluator.Print(oddNumbers);
            //GenericListEvaluator.GetNumbers<int>(numbers, ListEvaluator.Even);
            //GenericListEvaluator.Print(numbers);

            //var result = BuiltInDelegates.Example1(() => "Hello World");
            //Console.WriteLine(result);

            //BuiltInDelegates.Example2(() =>
            //{
            //    int x = 10;
            //    int y = 20;
            //    Console.WriteLine(x + y);
            //});

            //BuiltInDelegates.Example3(x => x % 2 == 0, 2);
            //predicates does not take two arguments
            //BuiltInDelegates.Example3((x,y) => x % 2 == 0, 2);
            //GenericCalculator.Calculate<int, int>(10, 4, GenericCalculator.Add);
            //Func<int, int, int> add = (x, y) => x + y;
            //GenericCalculator.Calculate<int,int>(10, 10, add);

            #endregion
            #region Multicast Delegate
            //Action action = () => Console.Write("Hello World ");
            //action += () => Console.Write("1");
            //action += () => Console.Write("2");
            //action += () => Console.Write("3");
            //action += () => Console.Write("4");
            //action();// Output: Hello World1234

            //Func<int, int, int> func = (x, y) => x + y;
            //func += (x, y) => x - y;
            //func += (x, y) => x * y;
            //func += (x, y) => x / y;


            //Console.WriteLine(func(10, 5)); // Output: 2

            //foreach (var item in func.GetInvocationList())
            //{
            //    Console.WriteLine(item.DynamicInvoke(10, 2));
            //}


            #endregion
            #region Events
            //Channel channel = new Channel("TachChannel");

            //Subsriber subsriber1 = new Subsriber("Ahmed");
            //Subsriber subsriber2 = new Subsriber("Mona");
            //Subsriber subsriber3 = new Subsriber("Mohamed");
            //Subsriber subsriber4 = new Subsriber("Yousra");

            //channel.AddSubscriber(subsriber1);
            //channel.AddSubscriber(subsriber2);
            //channel.AddSubscriber(subsriber3);
            //channel.AddSubscriber(subsriber4);

            //channel.AddVideo(new Video("Video1", "Description1"));
            //channel.RemoveSubscriber(subsriber1);
            //Console.WriteLine("===========");
            //channel.AddVideo(new Video("Video2", "Description2"));
            #endregion
            #region Dynamic 
            //Console.WriteLine(Sum(10, 2));//12
            #endregion
            #region Anonymous Type
            //var emp = new Employee(1, "Ahmed", 22222);

            ////anonymous type is immutable = read only
            //var emp1 = new { Id = 1, Name = "Ahmed", Salary = 22222 };

            ////compiler override tostring in codebehind
            //Console.WriteLine(emp1); //{ Id = 1, Name = Ahmed, Salary = 22222 }

            ////create object from anonymous type
            //var emp2 = emp1 with { Name = "Mona" };
            //Console.WriteLine(emp2); //{ Id = 1, Name = Mona, Salary = 22222 }


            //var emp3 = new { Id = 1, Name = "Ahmed", Salary = 22222 };
            //var emp4 = new { Id = 1, Name = "Ahmed", Salary = 22222 };
            //Console.WriteLine(emp3.GetType().Name); //<>f__AnonymousType0`3
            //Console.WriteLine(emp4.GetType().Name); //<>f__AnonymousType0`3

            //var emp5 = new { Id = 1, Name = "Ahmed", Salary = 22222 };
            //var emp6 = new { Id = 1, Salary = 22222, Name = "Ahmed" };
            //Console.WriteLine(emp5.GetType().Name); //<>f__AnonymousType0`3
            //Console.WriteLine(emp6.GetType().Name); //<>f__AnonymousType1`3
            #endregion
            #region ExtensionMethods
            //int value = 100;
            //Console.WriteLine(value.IsInRange());
            //Console.WriteLine(IntExtensions.IsInRange(value));
            #endregion
            #region LINQ

            /*
             * LINQ = Language Integrated Query , C#3.0
             * +40 extension methods exists in Enumerable class Categorized under 13 categories
             * extension method for IEnumerable interface, so any type implements IEnumerable {Array, List, Dictionary} can use +40 extension method
             * sequence = conllection
             * 1. Local Sequence = in memory {from object , from files linqToObject, linqToXML}
             *  ex: from object 
             *      List<int> list = new List<int>() { 1, 2, 3, 4, 5 };
             * 2. Remote Sequence = out of memory {from database, from web service linqToSQL, linqToEntity}
             * 
             * LINQ Syntax
             * 1. Fluent Syntax
             *   1.1 Calling Static Method {Extension Methods}   
             */

            //IEnumerable<int> numbers = Enumerable.Range(0, 20);
            //IEnumerable<int> evenNumbers = Enumerable.Where(numbers, n => n % 2 == 0);

            ///*
            // *   1.2 Calling Extension Methods
            // */
            //IEnumerable<int> evenNumbers2 = numbers.Where(n => n % 2 == 0);


            ///*
            // * 2. Query Syntax {Query Expression}
            // * start with from keyword => "Range Variable" in Collection
            // * must end with select or group by
            // */

            //var result = from number in numbers
            //             where number % 2 == 0
            //             select number;


            ///*
            // * 3. Hybrid Syntax
            // * 
            // */

            //result = (from number in numbers
            //          where number % 2 == 0
            //          select number).Where(n => n > 5);
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //} 
            #endregion

            #region Linq Execution
            //ProductList.ForEach(x => Console.WriteLine(x));
            //CustomerList.ForEach(x => Console.WriteLine(x));


            //var productList = ProductList.Where(x => x.UnitsInStock != 0 && x.UnitPrice > 10);

            //var productList = from p in ProductList
            //                  where p.UnitsInStock != 0 && p.UnitPrice > 10
            //                  select p;


            //var productList = ProductList.Where((product, index) => product.UnitsInStock == 0 && index <= 9);

            //var productList = ProductList.Select(product => product.ProductName);
            //productList = from product in ProductList
            //              select product.ProductName;

            //var productList = ProductList.Select(product => new Product
            //{
            //    ProductName = product.ProductName,
            //    UnitPrice = product.UnitPrice * 1.2m,
            //    UnitsInStock = product.UnitsInStock,
            //    Category = product.Category,
            //    ProductID = product.ProductID
            //}).Where(product => product.UnitPrice > 20);

            ////where has fixed place in query expression
            ////then introduce new range variable then apply filteration on this new range variable
            //productList = from product in ProductList
            //              select new Product
            //              {
            //                  ProductName = product.ProductName,
            //                  UnitPrice = product.UnitPrice * 1.2m,
            //                  UnitsInStock = product.UnitsInStock,
            //                  Category = product.Category,
            //                  ProductID = product.ProductID
            //              } into newProduct
            //              where newProduct.UnitPrice > 20
            //              select newProduct;

            //var productList = ProductList.Select((product, index) => $"{index} :: {product.ProductName}");

            //could return anonymous type
            //ProductName is dimmed as could be removed and take the name from the property "ProductName"
            // UnitOfPrice is not dimmed as PropertyName has changed

            //var productList = ProductList.Select(product => new {ProductName = product.ProductName, UnitOfPrice = product.UnitPrice });
            //var productList1 = ProductList.Select(product => new { product.ProductName, product.UnitPrice });

            //foreach (var product in productList)
            //    Console.WriteLine(product);

            //var orders = CustomerList.Select(c => c.Orders);

            //foreach (var order in orders)
            //{
            //    foreach (var item in order)
            //    {
            //        Console.WriteLine(item);
            //    }
            //}

            //var orders1 = CustomerList
            //    .SelectMany((c, i) => c.Orders.Select(order => new { Index = i, order.OrderId }));
            //foreach (var order in orders1)
            //{
            //    Console.WriteLine(order);
            //}


            //var result = CustomerList
            //    .SelectMany(
            //    (c, i) => c.Orders.Select(x => new { Index = i, x }),
            //    (c, l) => new { c.CustomerName, l });
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}

            //var result = CustomerList.SelectMany(s => s.Orders);

            //result = from c in CustomerList
            //         from o in c.Orders
            //         select o;


            //foreach (var item in result)
            //    Console.WriteLine(item);

            //var result = ProductList.OrderByDescending(x => x.UnitsInStock).ThenByDescending(x => x.UnitPrice);

            //result = from p in ProductList
            //         orderby p.UnitsInStock descending, p.UnitPrice descending
            //         select p;

            //foreach (var item in result)
            //    Console.WriteLine(item);

            ////Element Operators => Immediate Execution
            //// [First , Last]
            ////Returns the first or last element in the input sequence if exists otherwise throw exception
            //var result = ProductList.Last();
            //Console.WriteLine(result);

            //result = ProductList.First();
            //Console.WriteLine(result);

            //// [First(Func) , Last(Func)]
            ////Returns the first or last element in the input sequence that matches the delegate if exists otherwise throw exception
            //var result = ProductList.Last(p => p.UnitsInStock ==1000);
            //Console.WriteLine(result);

            //result = ProductList.First(p=> p.UnitPrice > 1000);
            //Console.WriteLine(result);

            //[FirstOrDefault, LastOrDefault]
            //Returns the first or last element in the input sequence if exists otherwise returns the default value for the sequence type
            //var result = ProductList.FirstOrDefault();
            //Console.WriteLine(result);

            //result = ProductList.FirstOrDefault(p => p.UnitsInStock > 1000);
            //result = ProductList.FirstOrDefault(new Product() { ProductID = 1});

            //List<int> ints = new List<int>();
            //Returns the first or last element in the input sequence if exists otherwise returns the default value = 5 for the sequence type
            //ints.FirstOrDefault(x=> x> 4,5);
            //ints.LastOrDefault(x=> x > 4,5);

            //var result = ProductList.ElementAt(10);
            //// like ProductList[10] incase is IEnumerable has no indexer
            //// index must exists else will throw exception
            //// 
            ////ElementAtOrDefault incase element not exists returns default type of object instead throw exception
            //result = ProductList.ElementAtOrDefault(10);
            //Console.WriteLine(result);

            ////[Single , SingleOrDefault]
            ////Single returns the only Element in the sequence and throws exception if the sequence is empty or contains more than one element
            //SingleOrDefault => returns the only element in the sequence and throws exception if the sequence contains more than one element 
            //and returns the default value if the sequence is empty
            ///returns default incase no elements and throw exception in case more than one element
            //List<int> ints = new List<int>();
            //var result = ints.SingleOrDefault(); //0

            //result = ints.Single(); // System.InvalidOperationException: 'Sequence contains no elements'

            //List<int> ints = new List<int>() { 1 };
            //var result = ints.SingleOrDefault(); //1
            //Console.WriteLine(result);


            //List<int> ints = new List<int>() { 1, 2 };
            //var result = ints.SingleOrDefault(x => x >= 2, 4); //2
            //Console.WriteLine(result);

            //List<int> ints = new List<int>() { 1, 2 };
            //var result = ints.SingleOrDefault(x => x >= 4, 4); //4
            //Console.WriteLine(result);

            //var counts = ProductList.Count(x => x.UnitsInStock == 0);
            //Console.WriteLine(counts);

            //var max = ProductList.MaxBy(x => x.UnitPrice); // return product
            //Console.WriteLine(max);

            //var sum = ProductList.Sum(x => x.UnitPrice);
            //Console.WriteLine(sum);

            //var avg = ProductList.Average(x => x.UnitPrice);
            //Console.WriteLine(avg);

            //var names = new List<string>() { "ahmed", "mona", "yousef", "kamal" };
            //var result = names.Aggregate("Mohamed", (acc, name) => $"{acc} {name}", x => x.Length);
            //Console.WriteLine(result);

            //var salary = new List<double>() { 122, 345, 566, 333 };
            //var result = salary.Aggregate((acc, salary) => acc + salary);

            //Console.WriteLine(result); //1366
            //Console.WriteLine(122 + 345 + 566 + 333);//1366

            //var products = ProductList.Where(p => p.UnitsInStock > 0).ToList();
            //products.ForEach(p =>
            //{
            //    Console.WriteLine(p);
            //});

            //var productArray = ProductList.Where(p => p.UnitsInStock > 0).ToArray();
            //foreach (var product in productArray)
            //    Console.WriteLine(product);

            //var productDictionary = ProductList.Where(p => p.UnitsInStock > 0).ToDictionary(p => p.ProductID);
            //foreach (var product in productDictionary)
            //    Console.WriteLine($"{product.Key} {product.Value}");

            //var productDictionary = ProductList.Where(p => p.UnitsInStock > 0)
            //    .ToDictionary(p => p.ProductID, p => p.ProductName);
            //foreach (var product in productDictionary)
            //    Console.WriteLine($"{product.Key} {product.Value}");

            //var productDictionary = ProductList.Where(p => p.UnitsInStock > 0)
            //    .ToDictionary(p => p.ProductID,
            //                  p => p.ProductName,
            //                  new ProductEqualityComparer());
            //foreach (var product in productDictionary)
            //    Console.WriteLine($"{product.Key} {product.Value}");

            //var productHashset = ProductList.ToHashSet();
            //Console.WriteLine(productHashset.Count); //77
            //foreach (var product in productHashset)
            //    Console.WriteLine(product);

            //var productHashset = ProductList.ToHashSet(new CustomProductEqualityComparer());

            //Console.WriteLine(ProductList.Count);//77
            //Console.WriteLine(productHashset.Count);//62

            //foreach (var product in productHashset)
            //    Console.WriteLine(product);
            #endregion
            #region Linq Generator
            //var range = Enumerable.Range(0, 100);
            //foreach (var x in range)
            //    Console.WriteLine(x);

            //var repeat = Enumerable.Repeat("$", 100);
            //foreach (var y in repeat)
            //    Console.WriteLine(y);

            ////Empty: used in where when no data matches Func return empty IEnumerable<int> or any type
            //var empty = Enumerable.Empty<int>();
            //foreach (var x in empty)
            //    Console.WriteLine(x);
            #endregion
            #region Linq Set Operator

            //var seq1 = Enumerable.Range(0, 100);
            //var seq2 = Enumerable.Range(50, 100);

            //var result = ProductList.Distinct(new CustomProductEqualityComparer());
            //var result = ProductList.DistinctBy( p => p.UnitsInStock);
            ////var result = seq1.Union(seq2);

            //foreach (var x in result)
            //    Console.Write($"{x},");
            //Console.WriteLine();
            //Console.WriteLine(result.Count()); // 154


            #endregion
            #region Linq Quantifier Operators
            //Console.WriteLine(ProductList.Any());
            //Console.WriteLine(ProductList.Any(p => p.UnitPrice > 0));

            //var range = Enumerable.Empty<Product>();
            //Console.WriteLine(range.Any());
            //Console.WriteLine(range.Any(p => p.UnitsInStock > 2));

            //Console.WriteLine(ProductList.All(p => p.UnitsInStock > 0));
            //Console.WriteLine(ProductList.All(p => p.UnitPrice > 0));
            //var range = Enumerable.Range(0, 100);
            //var range2 = Enumerable.Range(0, 100);
            //Console.WriteLine(range.SequenceEqual(range2)); // true



            #endregion
            #region Tuple
            //(string, int) x = ("Ahmed", 23);

            //Console.WriteLine(x.Item1);
            //Console.WriteLine(x.Item2);

            //(string name, int age) x2 = ("Ahmed", 23);
            //Console.WriteLine(x2.name);
            //Console.WriteLine(x2.age);

            //var numbers = new List<int>() { 1, 3, 4, 5, 6, 7, 8 };
            //var names = new List<string>() { "ahmed", "mona", "saad" };
            //var result = names.Zip(numbers);
            //foreach (var item in result)
            //    Console.WriteLine(item);

            //var numbers = new List<int>() { 1, 3, 4, 5, 6, 7, 8 };
            //var names = new List<string>() { "ahmed", "mona", "saad" };
            //var result = names.Zip(numbers, (x, y) => new { Name = x, Age = y });
            //foreach (var item in result)
            //    Console.WriteLine(item);


            #endregion
            #region Grouping
            //var result = ProductList.GroupBy(p => p.Category);
            //foreach (var group in result)
            //{
            //    Console.WriteLine($"{group.Key} :: count= {group.Count()}");

            //    foreach (var item in group)
            //    {
            //        Console.WriteLine($"\t\t{item}");
            //    }
            //    Console.WriteLine("--------------------");
            //}

            //var result = ProductList.GroupBy(p => p.Category, p => new
            //{
            //    p.ProductID,
            //    p.ProductName,
            //    p.UnitPrice
            //});
            //foreach (var group in result)
            //{
            //    Console.WriteLine($"{group.Key} :: count= {group.Count()}");

            //    foreach (var item in group)
            //    {
            //        Console.WriteLine($"\t\t{item}");
            //    }
            //    Console.WriteLine("--------------------");
            //}

            //var result = ProductList.GroupBy(p => p.Category, (categoryy, products) => new { categoryy, products });
            //foreach (var group in result)
            //{


            //    Console.WriteLine($"{group.categoryy} {group.products.Count()}");

            //    foreach (var item in group.products)
            //    {
            //        Console.WriteLine(item);
            //    }

            //}

            //var result = ProductList.GroupBy(
            //    p => p.Category,
            //    p => new
            //    {
            //        Id = p.ProductID,
            //        Name = p.ProductName
            //    },
            //    (a, b) => new
            //    {
            //        Category = a,
            //        Count = b.Count()
            //    }

            //);
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item.Category);
            //    Console.WriteLine(item.Count);

            //}

            //var query = from p in ProductList
            //            group p by p.Category;

            //foreach (var group in query)
            //{
            //    Console.WriteLine(group.Key);
            //    foreach (var item in group)
            //    {
            //        Console.WriteLine($"\t\t{item}");

            //    }
            //}

            //var query = from p in ProductList
            //            group p by p.Category
            //            into productGroup
            //            select new
            //            {
            //                Category = productGroup.Key,
            //                Count = productGroup.Count(),
            //                Products = productGroup.Select(p => new
            //                {
            //                    p.ProductID,
            //                    p.ProductName,
            //                    p.UnitPrice
            //                })
            //            };

            //foreach (var group in query)
            //{
            //    Console.WriteLine(group.Category);
            //    Console.WriteLine(group.Count);
            //    foreach (var product in group.Products)
            //    {
            //        Console.WriteLine($"\t\t{product.ProductID} {product.ProductName} {product.UnitPrice}");
            //    }


            //}

            //var query = from p in ProductList
            //            select new Product
            //            {
            //                ProductName = p.ProductName,
            //                Category = p.Category,
            //                UnitPrice = p.UnitPrice * 1.2m,
            //                UnitsInStock = p.UnitsInStock,
            //                ProductID = p.ProductID
            //            } into newProduct
            //            where newProduct.UnitPrice > 20
            //            select newProduct;

            //foreach (var item in query)
            //{
            //    Console.WriteLine(item);
            //}


            //var query = from p in ProductList
            //            let newProduct = new Product
            //            {
            //                ProductName = p.ProductName,
            //                Category = p.Category,
            //                UnitPrice = p.UnitPrice * 1.2m,
            //                UnitsInStock = p.UnitsInStock,
            //                ProductID = p.ProductID
            //            }
            //            where newProduct.UnitPrice > 20
            //            select newProduct;

            //foreach (var item in query)
            //{
            //    Console.WriteLine(item);
            //}


            #endregion
            #region skip -take - range
            // var result = ProductList.Skip(10); // start from id =11
            // foreach (var item in result)
            // {
            //     Console.WriteLine(item);
            // }

            // var product = ProductList[^1];//returned the last element in the list
            // Console.WriteLine(product);

            // List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Get range from index 2 to index 5(4 elements)
            // List<int> subset = numbers.GetRange(2, 4);

            // Console.WriteLine(string.Join(", ", subset)); // Output: 3, 4, 5, 6

            // var subset = numbers.Skip(2).Take(4).ToList();
            // Console.WriteLine(string.Join(", ", subset)); // Output: 3, 4, 5, 6

            // int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Get the last 3 elements
            //var lastThree = numbers[^3..];

            // Console.WriteLine(string.Join(", ", lastThree)); // Output: 8, 9, 10
            // var middle = numbers[2..^3]; // Gets elements between index 2 and third-from-last
            // Console.WriteLine(string.Join(", ", middle)); // Output: 3, 4, 5, 6, 7

            // var result = ProductList.Take(0..70);
            // foreach (var item in result)
            // {
            //     Console.WriteLine(item);
            // }

            //var result = ProductList.TakeLast(10);
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}

            //var result = ProductList.SkipLast(10);
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}

            //int pageNumber = 3, pageSize = 10;
            //var result = ProductList.Skip((pageNumber - 1) * pageSize).Take(pageSize);
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}


            //var result = ProductList.SkipWhile(p => p.UnitsInStock > 0);
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine(result.Count());



            #endregion

            #region Connection with database

            //using (var dataContext = new DataContext()) { }

            //dataContext scope in the container it exists in it
            //using DataContext dataContext = new DataContext();

            #region Add
            //var employee1 = new Employee() { Name = "Ahmed2" };

            //entry takes instance of Employee and track it in the context
            //Console.WriteLine(dataContext.Entry(employee1).State); // Output: Detached

            //- 1 -
            //dataContext.Employees.Add(employee1);

            //- 2 -
            //dataContext.Employees.Attach(employee1); // Attach the entity to the context

            //- 3 -
            //dataContext.Add(employee1); // Add the entity to the context

            //- 4 -
            //dataContext.Set<Employee>().Add(employee1); // Add the entity to the context using Set<T>()

            //- 5 -
            //dataContext.Entry(employee1).State = EntityState.Added; // Manually set the state to Added
            //Console.WriteLine(dataContext.Entry(employee1).State); // Output: Added

            //dataContext.SaveChanges();

            //Console.WriteLine(dataContext.Entry(employee1).State); // Output: Unchanged

            #endregion

            #region Retreive

            //var employee2 = dataContext.Employees.FirstOrDefault(e => e.Name == "Ahmed2");
            //if (employee2 != null)
            //    Console.WriteLine(dataContext.Entry(employee2).State); // Output: Unchanged

            //employee2 = dataContext.Employees.Find(1); // Find by primary key
            //if (employee2 != null)
            //    Console.WriteLine(dataContext.Entry(employee2).State); // Output: Unchanged

            //var employees = dataContext.Employees.Where(e => e.Salary > 1500); //IQueryable
            ////employees state are unchanged
            //IEnumerable<Employee> data = employees.ToList(); // Execute the query and load the data into memory

            //foreach (Employee employee in data)
            //    Console.WriteLine(dataContext.Entry(employee).State); //employees state are unchanged

            //employees = dataContext.Employees.Where(e => e.Salary > 1500).AsNoTracking(); // No tracking
            //                                                                              //employees state are detached


            //foreach (Employee employee in employees)
            //    Console.WriteLine(dataContext.Entry(employee).State);//employees state are detached
            //#endregion
            #endregion
            #region Update

            //var employee = dataContext.Employees.FirstOrDefault(e => e.EmpId == 5);
            //Console.WriteLine(dataContext.Entry(employee).State); // Output: Unchanged
            //employee.Name = "Wedad";
            //Console.WriteLine(dataContext.Entry(employee).State); // Output: Modified

            //dataContext.SaveChanges();

            //var employee2 = dataContext.Employees.AsNoTracking().FirstOrDefault(e => e.EmpId == 6);
            //Console.WriteLine(dataContext.Entry(employee2).State); // Output: Detached
            //employee2.Name = "Wedad";
            //Console.WriteLine(dataContext.Entry(employee2).State); // Output: Detached

            //dataContext.Employees.Update(employee2); // Attach the entity to the context and mark it as Modified
            //Console.WriteLine(dataContext.Entry(employee2).State); // Output: Modified

            //var employee3 = dataContext.Set<Employee>().Update(employee2); // Attach the entity to the context and mark it as Modified
            //Console.WriteLine(dataContext.Entry(employee2).State); // Output: Modified
            //dataContext.SaveChanges();

            #endregion

            #region delete
            //var employee = dataContext.Employees.FirstOrDefault(e => e.EmpId == 4);
            //Console.WriteLine(dataContext.Entry(employee).State); // Output: Unchanged

            //if (employee != null)
            //{
            //    //- 1 -
            //    //dataContext.Employees.Remove(employee);
            //    //- 2 -
            //    //dataContext.Entry(employee).State = EntityState.Deleted;
            //    //- 3 -
            //    //dataContext.Employees.RemoveRange(employee);
            //    //- 4 -
            //    dataContext.Set<Employee>().Remove(employee);
            //    Console.WriteLine(dataContext.Entry(employee).State); // Output: Deleted

            //    dataContext.SaveChanges();

            //    Console.WriteLine(dataContext.Entry(employee).State); // Output: Detached

            //}
            #endregion

            #region Many to Many
            //Course course = new Course() { Name = "C# Advanced" };
            //Student student = new Student() { Name = "Wedad" };
            //student.Courses = new List<Course>() { course };
            //course.Students = new List<Student>() { student };
            //dataContext.Courses.Add(course);
            //dataContext.Students.Add(student);
            //dataContext.SaveChanges();


            //CourseStudent courseStudent = new CourseStudent() { CourseId = course.Id, StudentId = student.Id, Grade = 100 };
            //dataContext.CourseStudent.Add(courseStudent);
            //dataContext.SaveChanges();

            #endregion

            #endregion

            #region TPH
            //using DataContext context = new DataContext();

            //context.ChangeTracker.QueryTrackingBehavior = Microsoft.EntityFrameworkCore.QueryTrackingBehavior.NoTracking;
            #region add

            //var fullTimeEmployee1 = new FullTimeEmployee() { Address = "Alex", Age = 22, Name = "Wedad", Salary = 9_888, StartDate = new DateOnly(2020, 10, 20) };
            //var fullTimeEmployee2 = new FullTimeEmployee() { Address = "Cairo", Age = 23, Name = "Ahmed", Salary = 9_9999, StartDate = new DateOnly(2020, 10, 20) };
            //var partTimeEmployee1 = new PartTimeEmployee() { Address = "Giza", Age = 24, Name = "Fathy", HourRate = 100, CountOfHours = 10 };
            //var partTimeEmployee2 = new PartTimeEmployee() { Address = "Giza", Age = 25, Name = "Galal", HourRate = 90, CountOfHours = 20 };

            //context.Employees.Add(partTimeEmployee1);
            //context.Employees.Add(partTimeEmployee2);
            //context.Employees.Add(fullTimeEmployee1);
            //context.Employees.Add(fullTimeEmployee2);
            //context.SaveChanges(); 
            #endregion
            #region retrieve 
            //var employees = context.Employees.ToList();
            //foreach (var employee in employees)
            //    Console.WriteLine(employee.Name);

            //var employees = context.Employees.OfType<FullTimeEmployee>();
            //foreach (var employee in employees)
            //{
            //    Console.WriteLine($"{employee.Name} {employee.Salary} {employee.StartDate}");
            //    employee.StartDate = new DateOnly(2020, 10, 20); // Update StartDate
            //    employee.Salary = 10_000; // Update Salary
            //}
            //context.SaveChanges();
            #endregion

            #region delete
            //var emp1 = context.Employees.Where(e => e.Name == "Wedad").FirstOrDefault();
            //if (emp1 != null)
            //{
            //    //- 1 -
            //    //context.Employees.Remove(emp1);
            //    //- 2 -
            //    //context.Entry(emp1).State = EntityState.Deleted;
            //    //- 3 -
            //    context.Set<CompanyEmployee>().Remove(emp1);
            //    Console.WriteLine(context.Entry(emp1).State); // Output: Deleted
            //    context.SaveChanges();
            //    Console.WriteLine(context.Entry(emp1).State); // Output: Detached
            //}
            #endregion

            #region update
            //var employee = context.Employees.Where(e => e.Name == "Ahmed").FirstOrDefault();
            //employee.Name = "Wedad";
            //if (employee != null)
            //{
            //    //- 1 -
            //    //context.Employees.Update(employee);
            //    //- 2 -
            //    //context.Entry(employee).State = EntityState.Modified;
            //    //- 3 -
            //    context.Set<CompanyEmployee>().Update(employee);
            //    Console.WriteLine(context.Entry(employee).State); // Output: Modified
            //    context.SaveChanges();
            //    Console.WriteLine(context.Entry(employee).State); // Output: Unchanged
            //}
            #endregion


            #endregion
            #region self relation
            //var manager = new Employee() { Name = "ManagerName" };
            //var employee = new Employee() { Name = "employeeName", Manager = manager };
            //using DataContext context = new DataContext();

            //context.Employees.Add(manager);
            //context.Employees.Add(employee);
            //Console.WriteLine(context.SaveChanges());


            #endregion

            #region loading related data
            //default not loading related data
            //using DataContext context = new DataContext();
            //var employee = context.Employees.FirstOrDefault(e => e.Name == "Ahmed");
            //if (employee is not null)
            //{
            //    Console.WriteLine($"Name: {employee.Name} :: Department: {employee.Department?.Name ?? "No Data"}");
            //}

            //// - 1 - Explicit loading in separated requests
            //using DataContext context = new DataContext();
            //var employee = context.Employees.FirstOrDefault(e => e.Name == "ManagerName");
            //if (employee is not null)
            //{
            //    //loading reference navigation property
            //    context.Entry(employee).Reference(e => e.Department).Load(); // Explicit loading
            //    Console.WriteLine($"Name: {employee.Name} :: Department: {employee.Department?.Name ?? "No Data"}");

            //    //loading collection navigation property
            //    context.Entry(employee).Collection(e => e.Employees).Load();// Explicit loading
            //    foreach (var item in employee.Employees)
            //    {
            //        Console.WriteLine(item.Name);
            //    }

            //}

            //// - 2 - Eager loading in one request with complex query
            //using DataContext context = new DataContext();
            //var employee = context.Employees
            //    .Include(e => e.Department) // Eager loading for reference navigation property
            //    .ThenInclude(e => e.Manager)
            //    //.Include(e => e.Employees) // Eager loading for collection navigation property
            //    .FirstOrDefault(e => e.Name == "ManagerName");

            //Console.WriteLine($"Name: {employee.Name} :: Department: {employee.Department?.Name ?? "No Data"}");
            //Console.WriteLine($"Name: {employee.Name} :: Department Manager Name: {employee.Department?.Manager?.Name ?? "No Data"}");


            // - 3 - Lazy Loading
            //install package Microsoft.EntityFrameworkCore.SqlServer
            //using DataContext context = new DataContext();
            //var employee = context.Employees.FirstOrDefault(e => e.Name == "ManagerName");
            //Console.WriteLine($"Name: {employee.Name} :: Department: {employee.Department?.Name ?? "No Data"}");
            //Console.WriteLine($"Name: {employee.Name} :: Department Manager Name: {employee.Department?.Manager?.Name ?? "No Data"}");
            //foreach (var item in employee.Employees)
            //{
            //    Console.WriteLine(item.Name);
            //}


            #endregion

            #region Local & find
            //using DataContext context = new DataContext();
            //var employees = context.Employees.ToList();

            //not need to make new request to database will get value from memory (RAM)
            //var employee = context.Employees.Local.FirstOrDefault(e => e.Name == "Ahmed");

            //if (employee is not null)
            //{
            //    Console.WriteLine($"Name: {employee.Name}");
            //}
            //else
            //{
            //    Console.WriteLine("Employee not found in local cache.");
            //}


            ////find works like calling local and if not exists in local make new request
            //var employee = context.Employees.Find(2);
            //if (employee is not null)
            //{
            //    Console.WriteLine($"Name: {employee.Name}");
            //}
            //else
            //{
            //    Console.WriteLine("Employee not found in local cache.");
            //}

            #endregion

            #region Join & Group Join

            //using DataContext context = new DataContext();

            //// - 1 - Linq syntenx
            //var employees = context.Employees.Join(context.Departments, e => e.DepartmentId, d => d.Id,
            //    (e, d) => new
            //    {
            //        EmployeeName = e.Name,
            //        Salary = e.Salary,
            //        DepartmentName = d.Name
            //    });
            //// - 2 - Query Expression
            //employees = from employee in context.Employees
            //            join department in context.Departments
            //            on employee.DepartmentId equals department.Id // should start with outer sequence =employee.departmentId
            //            select new
            //            {
            //                EmployeeName = employee.Name,
            //                Salary = employee.Salary,
            //                DepartmentName = department.Name
            //            };
            //foreach (var employee in employees)
            //{
            //    Console.WriteLine(employee);
            //}

            // should start with department as select employees for each department
            //var query = context.Departments.GroupJoin(context.Employees, d => d.Id, e => e.DepartmentId,
            //    (d, e) => new
            //    {
            //        DepartmentId = d.Id,
            //        DepartmentName = d.Name,
            //        Employees = e
            //    });

            //foreach (var d in query)
            //{
            //    Console.WriteLine($"Department Id: {d.DepartmentId} - Name: {d.DepartmentName} ");
            //    foreach (var item in d.Employees)
            //    {
            //        Console.WriteLine($"{item.Name} :: {item.Salary}");
            //    }
            //}
            #endregion

            #region View

            //using DataContext context = new DataContext();
            //foreach (var item in context.DepartmentEmployees)
            //{
            //    Console.WriteLine($"DeptName: {item.DepartmentName} :: EmployeeName:{item.EmployeeName}");
            //}

            #endregion
            #region Raw SQL

            //using DataContext context = new DataContext();
            //var query = context.Employees.FromSqlRaw("select * from Employees");
            //var query = context.Employees.FromSqlRaw("select * from Employees e where e.Id > 3");

            //int id = 2;
            //var query = context.Employees.FromSqlInterpolated($"select * from Employees e where e.Id > {id}");
            //foreach (var item in query)
            //{
            //    Console.WriteLine($"{item.Name}");
            //}
            //var rows = context.Database.ExecuteSql($"update employees set name = 'wedad' where id = 3");
            //Console.WriteLine(rows);

            //int employeeId = 4;
            //var rows = context.Database.ExecuteSqlInterpolated($"update employees set name = 'mohsen' where id = {employeeId}");
            //Console.WriteLine(rows);

            //context.Database.ExecuteSqlRawAsync()
            #endregion
            #region Stored procedure
            //using DataContext context = new DataContext();
            //var employees = context.GetEmployeesByDepartment(1);

            //foreach (var item in employees)
            //{
            //    Console.WriteLine($"{item.Name} ");
            //}

            //var employeeDetails = context.GetEmployeeWithDepartmentDetails(1);
            //foreach (var employee in employeeDetails)
            //{
            //    Console.WriteLine($"{employee.EmployeeName} :: {employee.DepartmentName}");
            //}

            //var departmentName = context.GetDepartmentName(1);
            //Console.WriteLine($"DepartmentNAME: {departmentName}");
            #endregion

            #region Dapper

            //Queries.QueryMethod();
            #endregion

            #region Benchmark
            //var run = BenchmarkRunner.Run<ExecutionTimeComparison>();
            #endregion

            #region tuple

            //var tuple1 = (Name: "Ahmed", Age: 23);
            //Console.WriteLine(tuple1.Name);

            //var tuple2 = GetDetails();
            //Console.WriteLine(tuple2.Item1);

            //var tuple3 = GetEnhancedDetails();
            //Console.WriteLine(tuple3.name);
            #endregion

            #region C# 7 pattern matching
            //// - 1 -
            //var x = 4;
            //if (x is int newX)
            //    Console.WriteLine(newX);

            //// - 2 -
            //var employee = new Employee()
            //{
            //    Name = "Wedad",
            //    Salary = 93_939
            //};
            //switch (employee)
            //{
            //    case Employee e when e.Salary < 1000:
            //        Console.WriteLine("Is of Type employee salary < 1000");
            //        break;
            //    case Employee e when e.Salary > 1000 && e.Salary < 10_000:
            //        Console.WriteLine("Is of Type employee salary between 1000 and 10000");
            //        break;
            //    case Employee e when e.Salary > 10_000:
            //        Console.WriteLine("Is of Type employee salary > 10000");
            //        break;
            //}

            #endregion

            #region Local Function

            //int Sum(int x, int y) => x + y;

            //Console.WriteLine(Sum(2, 3));
            #endregion

            #region C# 9 Records
            //record for class
            //EmployeeRecord record1 = new EmployeeRecord(12, "Ahmed", 1000);
            //immutable data structures.Records, whether class or struct,
            //record1.Salary = 9383; => error => immutable

            //provide built-in support for immutability and value equality.
            //EmployeeRecord record2 = new EmployeeRecord(12, "Ahmed", 1000);
            //Console.WriteLine(record1.Equals(record2)); // True


            //update using with and still immutable
            //var record3 = record1 with { Salary = 2000 };
            //Console.WriteLine(record3);

            //Method return record
            //EmployeeRecord GetRecord() => new EmployeeRecord(1, "Ahmed", 1000);
            //Console.WriteLine(GetRecord().Name);


            //record for struct
            //EmployeeRecordStruct recordStruct1 = new EmployeeRecordStruct(12, "Ahmed", 1000);
            //EmployeeRecordStruct recordStruct2 = new EmployeeRecordStruct(12, "Ahmed", 1000);
            //Console.WriteLine(recordStruct1.Name);
            //Console.WriteLine(recordStruct1.Equals(recordStruct2));//true

            //DepartmentRecord departmentRecord = new DepartmentRecord();
            //departmentRecord.Name = "HR";
            //departmentRecord.Id = 1;
            //departmentRecord.Name = "IT";
            #endregion

            #region C# 8 Option Switch
            //string value = "Ahmed";
            //string result = value switch
            //{ 
            //    "Ahmed" => "Hello Ahmed",
            //    "Mohamed" => "Hello Mohamed",
            //    "Wedad" => "Hello Wedad",
            //    _ => "Unknown" // default value
            //};

            //Console.WriteLine(result);


            Employee employee = new Employee()
            {
                Name = "Ahmed",
                Salary = 1000
            };

            string employeeResult = employee switch
            {
                { Salary: < 1000 } => "Employee has low salary",
                { Salary: >= 1000 and < 5000 } => "Employee has medium salary",
                { Salary: >= 5000 } => "Employee has high salary",
                { Name: "Wedad" or "Ahmed" } => "Employee is Wedad or Ahmed",
                { Name: "Mohamed" } => "Employee is Mohamed",
                { } => "Employee has no specific condition",
                _ => "Unknown"
            };
            Console.WriteLine(employeeResult);


            #endregion
        }
    }
}
