using System.ComponentModel.DataAnnotations;

namespace MVC_Day6.ViewModels.Course
{
    public class StudentCourseSearchViewModel
    {
        [Required(ErrorMessage = "Student ID is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid Student ID")]
        public int StudId { get; set; }

        [Required(ErrorMessage = "Course ID is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid Course ID")]
        public int CourseId { get; set; }
    }
}
