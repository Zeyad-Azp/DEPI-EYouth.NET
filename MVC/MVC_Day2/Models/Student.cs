using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Day1.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Range(18,60)]
        public int Age { get; set; }
        [ForeignKey("dept")]
        public int? DepartmentId { get; set; }
        public Department? dept { get; set; }
        public ICollection<StuCrsRes>? StudentCourse { get; set; }
    }
}
