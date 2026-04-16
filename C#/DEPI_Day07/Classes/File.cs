using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEPI_Day07
{
    internal class File : IReadable , IWritable
    {
        public void Read() 
        {
            Console.WriteLine("-- Read from file class --");
        }
        public void Write() 
        {
            Console.WriteLine("-- Write on file class --");
        }

    }
}
