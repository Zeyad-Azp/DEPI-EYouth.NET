using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEPI_Day08.Classes
{
    internal class Student : ICloneable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Grade { get; set; }
        public Student(int id, string name, double grade)
        {
            Id = id;
            Name = name;
            Grade = grade;
        }
        // copy ctor
        public Student (Student copy)
        {
            Id = copy.Id;
            Name = copy.Name;
            Grade = copy.Grade;
        }
        public object Clone()
        {
            return new Student(this);
        }
    }
}
