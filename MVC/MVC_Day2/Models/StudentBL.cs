using Microsoft.EntityFrameworkCore;
using MVC_Day1.Data.Context;

namespace MVC_Day1.Models
{
    public class StudentBL
    {
        public TaskDbContext context = new TaskDbContext();
        public List<Student> ShowAll()
        {
            return context.Students.Include(s => s.dept).ToList();
        }
        public Student ShowDetails(int id)
        {
            return context.Students.Include(s => s.dept).FirstOrDefault(s => s.Id == id);
        }
    }
}
