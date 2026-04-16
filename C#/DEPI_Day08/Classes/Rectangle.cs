using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEPI_Day08.Classes
{
    internal class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Hieght { get; set; }
        public override double GetArea()
        {
            return Width * Hieght;
        }
        public override string Display()
        {
            return $"This is a Rectangle... with area {GetArea()}";
        }
        public Rectangle(double width , double hieght)
        {
            Width = width;
            Hieght = hieght;
        }
    }
}
