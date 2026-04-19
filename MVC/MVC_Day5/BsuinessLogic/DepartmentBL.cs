using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Day5.Data.Context;
using MVC_Day5.Models;
using MVC_Day5.ViewModels.Department;

namespace MVC_Day5.BsuinessLogic
{
    public class DepartmentBL
    {
        public Task5DbContext context = new Task5DbContext();
        public List<Department> GetAll()
        {
            return context.Departments.ToList();
        }
        public Department GetById(int id)
        {
            return context.Departments.FirstOrDefault(d => d.Id == id);
        }
        public DepartmentViewModel Details(int id)
        {
            Department dept = GetById(id);
            DepartmentViewModel DeptViewModel = new DepartmentViewModel() 
            {
                Name = dept.Name,
                Students = dept.Students?.Where(s => s.Age > 25).Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.Name
                }).ToList(),
                State = dept.Students?.Count() > 50 ? DepartmentState.Main : DepartmentState.branch
            };
            return DeptViewModel;
        }
        public void Add(Department dept)
        {
            context.Departments.Add(dept);
            context.SaveChanges();
        }
    }
}
