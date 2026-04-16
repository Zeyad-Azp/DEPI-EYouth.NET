using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEPI_Day07
{
    internal class Child : Parent
    {
        public int z { get; set; }
        public Child(int _x , int _y , int _z) : base(_x , _y)
        {
            z = _z;
        }
        // override using new
        public new int Product()
        {
            return x * y * z;
        }
        // override using virtual + override
        public override int sum()
        {
            return x * y * z;
        }
        public override string ToString()
        {
            return $"({x} , {y} , {z})";
        }
    }
}
