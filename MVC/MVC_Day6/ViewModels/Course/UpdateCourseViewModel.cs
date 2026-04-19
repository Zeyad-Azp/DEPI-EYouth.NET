using System.ComponentModel.DataAnnotations;

namespace MVC_Day6.ViewModels.Course
{
    public class UpdateCourseViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Course name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Degree is required")]
        [Range(0, 100, ErrorMessage = "Degree must be between 0 and 100")]
        public double Degree { get; set; }

        [Required(ErrorMessage = "Min Degree is required")]
        [Range(0, 100, ErrorMessage = "Min Degree must be between 0 and 100")]
        public double MinDegree { get; set; }

        [Required(ErrorMessage = "Department is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a department")]
        public int DepartmentId { get; set; }
    }
}
