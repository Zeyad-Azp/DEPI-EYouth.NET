using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEPI_Day08.Classes
{
    internal class Product : IComparable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Product(int id , string name , decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
        public int CompareTo(Object? obj)
        {
            if (obj is null)
                return 0;
            Product passed = (Product)obj;
            if (Price > passed?.Price)
            {
                return 1;
            }
            else if (Price < passed?.Price)
            {
                return -1;
            }
            return 0;
        }
        public override string ToString()
        {
            return $"Product => Id : {Id} , Name : {Name} , Price : {Price}";
        }
    }
}
