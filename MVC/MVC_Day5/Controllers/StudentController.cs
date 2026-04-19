using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Day5.BsuinessLogic;
using MVC_Day5.Models;
using MVC_Day5.ViewModels.Student;

namespace MVC_Day5.Controllers
{
    public class StudentController : Controller
    {
        StudentBL studentBl = new StudentBL();
        DepartmentBL departmentBL = new DepartmentBL();

        public IActionResult Index()
        {
            ViewBag.Departments = new SelectList(departmentBL.GetAll() , "Id" , "Name");
            List<Student> list = studentBl.ShowAll();
            return View("Index", list);
        }
        public IActionResult ShowDetails(int id)
        {
            Student student = studentBl.ShowDetails(id);
            if (student == null)
                return RedirectToAction(nameof(Index));
            return View("ShowDetails", student);
        }
        public IActionResult AddStudent()
        {
            ViewBag.Departments = new SelectList(departmentBL.GetAll(), "Id", "Name");
            return View("AddStudent", new Student());
        }
        [HttpPost]
        public IActionResult SaveAdd(Student student)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Departments = new SelectList(departmentBL.GetAll(), "Id", "Name");
                return View("AddStudent", student);
            }
            studentBl.Add(student);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            return View("Delete", studentBl.ShowDetails(id));
        }
        [HttpPost]
        public IActionResult ConfirmDelete(int id)
        {
            studentBl.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Update(int id)
        {
            //Student student = studentBl.ShowDetails(id);
            //if (student == null)
            //    return View("Update", student);

            ViewBag.Departments = new SelectList(departmentBL.GetAll(), "Id", "Name");
            return View("Update", studentBl.ShowDetails(id));
        }
        [HttpPost]
        public IActionResult SaveUpdate(UpdateViewModel VM)
        {
            var student = studentBl.ShowDetails(VM.Id);
            student.Name = VM.Name;
            student.Age = VM.Age;
            student.DepartmentId = VM.DepartmentId;
            studentBl.Update(student);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Search(string name)
        {
            if (string.IsNullOrEmpty(name))
                return RedirectToAction(nameof(Index));
            List<Student> list = studentBl.Search(name);
            return View("Index", list);
        }
        public IActionResult Filter(int DepartmentId)
        {
            var students = studentBl.ShowAll().Where(s => s.dept?.Id == DepartmentId).ToList();
            ViewBag.Departments = new SelectList(departmentBL.GetAll(), "Id", "Name");
            return View("Index", students);
        }
    }
}
