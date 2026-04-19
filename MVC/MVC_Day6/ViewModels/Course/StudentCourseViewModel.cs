using System.ComponentModel.DataAnnotations;
namespace MVC_Day6.ViewModels.Course
{
    public class StudentCourseViewModel
    {
        [Required(ErrorMessage = "Student name is required")]
        public string StudentName { get; set; }

        [Required(ErrorMessage = "Course name is required")]
        public string CourseName { get; set; }

        [Required(ErrorMessage = "Grade is required")]
        [Range(0, 100, ErrorMessage = "Grade must be between 0 and 100")]
        public double grade { get; set; }
        public string Result { get; set; }
        public string ResultClass { get; set; }
    }
}