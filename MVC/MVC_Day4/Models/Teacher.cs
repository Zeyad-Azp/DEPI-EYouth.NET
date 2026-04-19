namespace MVC_Day4.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public string Address { get; set; }
        public int DepartmentId { get; set; }
        public int CourseId { get; set; }
        public Department dept { get; set; }
        public Course course { get; set; }
    }
}
