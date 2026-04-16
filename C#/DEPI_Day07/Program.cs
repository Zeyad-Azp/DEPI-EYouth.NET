namespace DEPI_Day07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region part_1
            #region program_1
            // default ctor
            Car c00 = new Car();
            // parametarized ctor taking 2 params
            Car c01 = new Car(1 , "kia");
            // parametarized ctor taking 3 params
            Car c02 = new Car(1, "kia" , 1000000m);
            #endregion
            #region question_1
            // Question: Why does defining a custom constructor suppress the default constructor in C#? 
            /*
             * because when you need to define a parametarized ctor , you already have a business rule to apply
             * example : you need each one creating an object must set the name
             * if you defined a param ctor and the default is still working => your business is not appling
             */
            #endregion

            #region program_2
            // first overload => sum two integers
            Console.WriteLine(Calculator.Sum(10 , 20));

            // second overload => sum three integers
            Console.WriteLine(Calculator.Sum(10, 20 , 30));

            // third overload => sum two doubles
            Console.WriteLine(Calculator.Sum(10.7, 20.4));
            #endregion
            #region question_2
            // Question: How does method overloading improve code readability and reusability?  
            /*
             * method overloading improves readability because you will write more than implementation & signeture using one function name
             * method overloading improves reusability because you will use the same function name in all cases you need instead of using complex names
             *  and you can use any overloaded function in another overloaded one
             */
            #endregion

            #region program_3
            Child c = new Child(10 , 15 , 20);
            #endregion
            #region question_3
            // Question: What is the purpose of constructor chaining in inheritance?  
            /*
             * constructor chaining makes you avoid code repetition
             * and makes you apply the generalization & clean code
             * and it ensure that the parent is in a valid state before creating the child object to apply inheritance correctly
             */
            #endregion

            #region program_4
            Parent p = new Parent(50 , 50);
            Console.WriteLine(p.Product());
            Console.WriteLine(p.sum());


            Child c03 = new Child(50 , 50 , 20);
            Console.WriteLine(c03.Product());
            Console.WriteLine(c03.sum());

            p = c03;
            Console.WriteLine(p.Product()); // the overrideing using new keyword makes the CLR goes to the REF not the object
            Console.WriteLine(p.sum()); // the overrideing using virtual + override keywords make the CLR goes to the object not the REF
            #endregion
            #region question_4
            // Question: How does new differ from override in method overriding?  
            /*
             * new : 
             * makes Parent hiding => it hides the parent method from the child by creating a new one outside the VTable
             * so , when a parent reference is pointing to a child object => this case is a static binding which means that the method
             * has been determined by the compiler in the compile time based on the reference type not the object
             * 
             * virtual + override : 
             * in this case you let to the child class to change the parent behavior which he inherited from him by modifing the 
             * VTable entry to contain the child method address instead of parent => this case is a dynamic binding which means 
             * that the method will be determined in the runtime by the CLR by ensuring that the called method is virtual then , 
             * searching on an overrided one in the object VTable , if the object overrided this virtual method , it it will be called
             * if not the parent version will be called
             */
            #endregion

            #region program_5
            Parent p01 = new Parent(10 , 20);
            Child c04 = new Child(10, 20 , 50);

            Console.WriteLine(p01); // (10 , 20)
            Console.WriteLine(c04); // (10 , 20 , 50)
            #endregion
            #region question_5
            // Question: Why is ToString() often overridden in custom classes? 
            /*
             * because its default behavior is printing the namespace of the object and in many cases you need to change this behavior
             * to apply any business case you need 
             * any string representation to your object
             */
            #endregion

            #region program_6
            Rectangle r = new Rectangle();
            r.Area = 50;
            r.Draw();
            #endregion
            #region question_6
            // Question: Why can't you create an instance of an interface directly?  
            /*
             * because the interface is an abstraction layer which means that it is not complete
             * it designed to has no implementation and may contains a default implementation to avoid repetetion
             * between the classes which will implement the interface
             */
            #endregion

            #region program_7
            IShape circle = new Circle();
            circle.PrintDetails();
            #endregion
            #region question_7
            // Question: What are the benefits of default implementations in interfaces introduced in C# 8.0?  
            /*
             * it makes you avoid the code repetition in the classes which implement the interface
             * and you can access this default implemented method from a reference of the interface
             */
            #endregion

            #region program_8
            File f = new File();
            f.Read();
            f.Write();
            #endregion
            #region question_8
            // Question: How does C# overcome the limitation of single inheritance with interfaces?  
            /*
             * by using the multiple interface implementation , which means that one class can implement
             * more thane one interface
             */
            #endregion

            #region program_9
            Rectangle2 r01 = new Rectangle2();
            r01.Width = 10.45;
            r01.Hieght = 7.56;
            Console.WriteLine(r01.CalcArea());
            #endregion
            #region question_9
            // Question: What is the difference between a virtual method and an abstract method in C#? 
            /*
             * virtual : 
             *      - it used with the functions & properties in the classes to let you change its behavior when you inherit
             *          from its class or keep it the same
             *      - it is added to the virtual table of its class
             *      
             * abstract :
             *      - it used with the functions in the classes and you can not implement it , you write abstract
             *          to let the inherited classes to implement this function
             *      - once you write it in your class you must change your class to be an abstrct class
             */
            #endregion
            #endregion
            #region part_2
            #region question_1
            /*
             * Class : 
             *      private for members by default
             *      Supports inheritance(can be base or derived)
             *      Allocated on heap(dynamic memory) usually, accessed via pointer or reference
             *      Supports virtual functions, runtime polymorphism
             *      Can have default and parameterized constructors, destructor allowed
             *      Copying copies pointer/reference(shallow copy)
             * struct : 
             *      private for members by default
             *      Cannot be inherited , structs cannot inherit from another struct/class
             *      Allocated on stack(value type) usually
             *      cannot have explicit parameterless constructor
             *      Copying copies entire value(deep copy by default)
             *      For simple data containers, lightweight objects
             */
            #endregion
            #region question_2
            //If inheritance is relation between classes clarify other relations between classes  
            /*
             * Association => a class has a relation with another class
             * Aggregation => a class01 contain another class02 but class02 can survive when the class01 destroy
             * Composition => a class01 contain another class02 but class02 can NOT survive when the class01 destroy
             */
            #endregion
            #endregion
        }
    }
}
