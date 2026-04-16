using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEPI_Day08.Classes
{
    internal class Circle : Shape
    {
        public double R { get; set; }
        public override double GetArea()
        {
            return Math.PI * Math.Pow(R , 2);
        }
        public override string Display()
        {
            return $"This is a Circle... with area {GetArea()}";
        }
        public Circle(double r)
        {
            R = r;
        }
    }
}
