using DEPI_Day08.Interfaces;
using DEPI_Day08.Classes;
namespace DEPI_Day08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region program_1
            // car object
            IVehicle car = new Car();
            car.StartEngine();
            car.StopEngine();

            // bike object
            IVehicle bike = new Bike();
            bike.StartEngine();
            bike.StopEngine();
            #endregion
            #region question_1
            //Question: Why is it better to code against an interface rather than a concrete class?  
            /*
             * using the interfaces give you more 
             * 1.   flexibility in you code which means that you can extend 
             *      your business by creating more classes which implement the one interface
             * 2.   easy maintinance : the system depends on an abstraction not a concrete class with a 
             *      specific implementation , so you can extend the code without modifing the existing code
             * 3.   appling the O/C prencible     
             */
            #endregion

            #region program_2
            Rectangle r = new Rectangle(10,20);
            Circle c = new Circle(15);
            Console.WriteLine(r.Display());
            Console.WriteLine(c.Display());
            #endregion
            #region question_2
            //Question: When should you prefer an abstract class over an interface?  
            /*
             * 1. when you need a layer to contain the common members between your classes
             * 2. when you want your class to inherit some members and implement some members
             */
            #endregion

            #region program_3
            Product[] array = new Product[3];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = new Product(i+1 , $"laptop {i+2}" , 100000 - (decimal)Math.Pow(i+16,2));
            }
            Array.Sort(array);
            foreach(Product p in array)
            {
                Console.WriteLine(p);
            }
            #endregion
            #region question_3
            //Question: How does implementing IComparable improve flexibility in sorting?  
            /*
             * the sort function already uses CompareTo , so when you need to use it you must implement the
             * IComparable Interface and override the CompareTo method with your own business
             */
            #endregion

            #region program_4
            Student s1 = new Student(1, "Ali", 90);

            // Shallow copy
            Student shallow = s1;

            // Deep copy
            Student deep = (Student)s1.Clone();

            shallow.Name = "Omar";

            Console.WriteLine(s1.Name);
            Console.WriteLine(shallow.Name);
            Console.WriteLine(deep.Name);
            #endregion
            #region question_4
            //Question: What is the primary purpose of a copy constructor in C#? 
            /*
             * appling the deep copy between the objects
             */
            #endregion

            #region program_5
            IWalkable r01 = new Robot();
            r01.Walk();
            #endregion
            #region question_5
            //Question: How does explicit interface implementation help in resolving naming conflicts?
            /*
             * when you have some functions with the same name in more than one interface and 
             * you have a class must implement these interfaces => if you used the normal approach ,
             * the class will consider the one implementation will be for all the functions which have the 
             * same name and this is wrong
             * in this case you must use explicit interface implementation because it will help you by making 
             * each function is belong to its interface not the class , and you will nor be able to access these
             * functions from a class reference , you must use an interface reference
             * 
             */
            #endregion

            #region program_6
            #endregion
            #region question_6
             
            #endregion
        }
    }
}

