using Microsoft.EntityFrameworkCore;
using MVC_Day6.Data.Context;
using MVC_Day6.Models;

namespace MVC_Day6.BsuinessLogic
{
    public class CourseBL
    {
        Task6DbContext context = new Task6DbContext();
        public List<Course> GetAll()
        {
            return context.Courses
                .Include(c => c.Dept)
                .ToList();
        }
        public Course GetById(int id)
        {
            return context.Courses
                .Include(c => c.Dept)
                .FirstOrDefault(c => c.Id == id);
        }
            public void Add(Course course)
            {
                context.Courses.Add(course);
                context.SaveChanges();
            }
            public void Update(Course course)
            {
                context.Courses.Update(course);
                context.SaveChanges();
            }
            public void Delete(int id)
            {
                Course course = GetById(id);
                if (course != null)
                {
                    context.Courses.Remove(course);
                    context.SaveChanges();
                }
        }
    }
}
