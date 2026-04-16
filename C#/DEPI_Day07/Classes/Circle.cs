using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEPI_Day07
{
    internal class Circle : IShape
    {
        public double Area { get; set; }
        public void Draw()
        {
            Console.WriteLine("-- Circle Shape --");
        }
    }
}
