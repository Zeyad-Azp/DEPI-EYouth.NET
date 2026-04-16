using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEPI_Day07
{
    internal class Rectangle2 : Shape
    {
        public double Width { get; set; }
        public double Hieght { get; set; }
        public override void Draw()
        {
            Console.WriteLine("Drawing The Rectangle...");
        }
        public override double CalcArea()
        {
            return Width * Hieght;
        }
    }
}
