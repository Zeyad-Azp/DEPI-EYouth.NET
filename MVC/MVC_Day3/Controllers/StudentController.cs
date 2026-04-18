using Microsoft.AspNetCore.Mvc;
using MVC_Day3.Models;

namespace MVC_Day3.Controllers
{
    public class StudentController : Controller
    {
        StudentBL studentBl = new StudentBL();
        public IActionResult Index()
        {
            List<Student> list = studentBl.ShowAll();
            return View("Index" , list);
        }
        public IActionResult ShowDetails(int id)
        {
            
            Student student = studentBl.ShowDetails(id);
            return View("ShowDetails", student);
        }
    }
}
