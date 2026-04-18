using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MVC_Day3.Models;
using MVC_Day3.ViewModels.Department;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MVC_Day3.Controllers
{
    public class DepartmentController : Controller
    {
        /*
         * Security case:
                We use ViewModel to hide sensitive data like password or salary and only send safe data to the View
           Combining models:
                We use ViewModel when we need data from more than one model in a single page
           UI shaping:
        We use ViewModel when the View needs only some fields from the model, not all the data
        */
        public DepartmentBL departmentBL = new DepartmentBL();
        public IActionResult Index()
        
        {
            List<Department> depts = departmentBL.GetAll();
            return View(depts);
        }
        public IActionResult AddDept()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SaveAdd(Department dept)
        {
            departmentBL.Add(dept);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult ShowDetails(int id)
        {
            DepartmentViewModel deptVM = departmentBL.Details(id);
            return View(deptVM);
        }
    }
}
