using Microsoft.EntityFrameworkCore;
using MVC_Day3.Data.Context;

namespace MVC_Day3.Models
{
    public class StudentBL
    {
        public Task3DbContext context = new Task3DbContext();
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
