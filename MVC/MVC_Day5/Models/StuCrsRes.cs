using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Day5.Models
{
    public class StuCrsRes
    {
        [ForeignKey("student")]
        public int StudentId { get; set; }
        [ForeignKey("course")]
        public int CourseId { get; set; }
        public double grade { get; set; }
        public Student student { get; set; }
        public Course course { get; set; }
    }
}
