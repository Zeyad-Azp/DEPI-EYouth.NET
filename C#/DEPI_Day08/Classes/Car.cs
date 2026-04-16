using DEPI_Day08.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEPI_Day08.Classes
{
    internal class Car : IVehicle
    {
        public void StartEngine()
        {
            Console.WriteLine("Car StartEngine...");
        }
        public void StopEngine()
        {
            Console.WriteLine("Car StopEngine...");
        }
    }
}
