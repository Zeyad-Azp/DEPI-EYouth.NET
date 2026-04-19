using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Day6.BsuinessLogic;
using MVC_Day6.Models;
using MVC_Day6.ViewModels.Course;
using System;
using System.Diagnostics.Metrics;
using System.Dynamic;
using System.Threading;

namespace MVC_Day6.Controllers
{
    public class CourseController : Controller
    {
        CourseBL courseBL = new CourseBL();
        StudentBL studentBl = new StudentBL();
        DepartmentBL departmentBL = new DepartmentBL();
        public IActionResult Index()
        {
            var courses = courseBL.GetAll();
            return View(courses);
        }
        public IActionResult GetById(int id)
        {
            var course = courseBL.GetById(id);
            if (course == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }
        public IActionResult Add()
        {
            ViewBag.depts = new SelectList(departmentBL.GetAll(), "Id", "Name");
            return View(new AddCourseViewModel());
        }
        [HttpPost]
        public IActionResult SaveAdd(AddCourseViewModel courseVM)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.depts = new SelectList(departmentBL.GetAll(), "Id", "Name");
                return View("Add", courseVM);
            }
            var course = new Course
            {
                Name = courseVM.Name,
                Degree = courseVM.Degree,
                MinDegree = courseVM.MinDegree,
                DepartmentId = courseVM.DepartmentId
            };
            courseBL.Add(course);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Update(int id)
        {
            var course = courseBL.GetById(id);
            if (course == null)
            {
                return RedirectToAction(nameof(Index));
            }
            ViewBag.depts = new SelectList(departmentBL.GetAll(), "Id", "Name", course.DepartmentId);
            var courseVM = new UpdateCourseViewModel
            {
                Id = id,
                Name = course.Name,
                Degree = course.Degree,
                MinDegree = course.MinDegree,
                DepartmentId = course.DepartmentId
            };
            return View(courseVM);
        }
        public IActionResult SaveUpdate(UpdateCourseViewModel courseVM)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.depts = new SelectList(departmentBL.GetAll(), "Id", "Name", courseVM.DepartmentId);
                return View("Update", courseVM);
            }
            var course = courseBL.GetById(courseVM.Id);
            course.Name = courseVM.Name;
            course.Degree = courseVM.Degree;
            course.MinDegree = courseVM.MinDegree;
            course.DepartmentId = courseVM.DepartmentId;
            courseBL.Update(course);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            var course = courseBL.GetById(id);
            if (course == null)
            {
                return RedirectToAction(nameof(Index));
            }
            var courseVM = new DeleteCourseViewModel
            {
                Id = id,
                Name = course.Name,
                Degree = course.Degree,
                MinDegree = course.MinDegree,
                DepartmentName = course.Dept.Name
            };
            return View(courseVM);
        }
        public IActionResult ConfirmDelete(int id)
        {
            courseBL.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult StudentCourseView()
        {
            return View(new StudentCourseSearchViewModel());
        }
        [HttpPost]
        public IActionResult StudentCourse(StudentCourseSearchViewModel VM)
        {
            var student = studentBl.ShowDetailsWithCourses(VM.StudId);
            if (student == null)
            {
                return RedirectToAction(nameof(Index));
            }
            var result = student.StudentCourse?.FirstOrDefault(sc => sc.CourseId == VM.CourseId);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }
            var course = courseBL.GetById(VM.CourseId);
            var studentCourseVM = new StudentCourseViewModel
            {
                StudentName = student.Name,
                CourseName = course.Name,
                grade = result.grade ?? 0,
                Result = result.grade > 50 ? "Passed" : "Failed",
                ResultClass = result.grade > 50 ? "bg-success" : "bg-danger"
            };
            
            return View(studentCourseVM);
        }
    }
}
/*
1) Three use cases we need asynchronous programming
Asynchronous programming is used when we don’t want to block the main thread while waiting for a long operation
Common cases are =? calling web APIs, reading/writing files and database operations to improve performance and responsiveness

2) Difference between Thread and Task
Thread is a low-level OS concept that directly runs code and is heavier to manage
Task is a higher-level abstraction built on threads that is easier to use and managed by the .NET runtime for better performance

3) New features in .NET 9 for Generic types operations
.NET 9 improves performance and flexibility in generic math and collections using better generic constraints and optimizations
It also enhances support for generic math interfaces like INumber<T> to perform arithmetic operations on generic types efficiently

4) Built-in delegate types in detail
Built-in delegates in C# include Action, Func and Predicate
Action is used for methods with no return value, Func is used for methods that return a value, and Predicate returns a boolean value
*/