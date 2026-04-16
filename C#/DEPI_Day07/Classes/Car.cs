using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEPI_Day07
{
    internal class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        
        public Car() { }
        public Car(int id) { 
            Id = id; 
        }
        public Car(int id , string brand) {
            Id = id;
            Brand = brand;
        }
        public Car(int id, string brand , decimal price)
        {
            Id = id;
            Brand = brand;
            Price = price;
        }
    }
}
