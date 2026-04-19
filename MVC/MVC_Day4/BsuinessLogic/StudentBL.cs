using Microsoft.EntityFrameworkCore;
using MVC_Day4.Data.Context;
using MVC_Day4.Models;

namespace MVC_Day4.BsuinessLogic
{
    public class StudentBL
    {
        public Task4DbContext context = new Task4DbContext();
        public List<Student> ShowAll()
        {
            return context.Students.Include(s => s.dept).ToList();
        }
        public Student ShowDetails(int id)
        {
            return context.Students.Include(s => s.dept).FirstOrDefault(s => s.Id == id);
        }
        public void Add(Student student)
        {
            context.Students.Add(student);
            context.SaveChanges();
        }   
        public void Update(Student student)
        {
            context.Students.Update(student);
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            Student student = context.Students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                context.Students.Remove(student);
                context.SaveChanges();
            }
        }
        public List<Student> Search(string name)
        {
            return context.Students.Where(s => s.Name.Contains(name)).Include(s => s.dept).ToList();
        }
    }
}
