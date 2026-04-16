using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEPI_Day07
{
    internal interface IShape
    {
        double Area { get; }
        void Draw();
        void PrintDetails()
        {
            Console.WriteLine("This is a Shape");
        }
    }
}
