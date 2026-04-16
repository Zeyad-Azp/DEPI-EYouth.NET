using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEPI_Day08.Classes
{
    internal abstract class Shape
    {
        public abstract double GetArea();
        public virtual string Display()
        {
            return "This is a Shape...";
        }
    }
}
