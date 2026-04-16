using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEPI_Day07
{
    internal class Parent
    {
        public int x { get; set; }
        public int y { get; set; }
        public Parent(int _x , int _y)
        {
            x = _x;
            y = _y;
        }
        public int Product()
        {
            return x * y;
        }
        public virtual int sum()
        {
            return x + y;
        }
        public override string ToString()
        {
            return $"({x} , {y})";
        }
    }
}
