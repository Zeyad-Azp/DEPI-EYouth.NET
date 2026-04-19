namespace MVC_Day4.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Degree { get; set; }
        public double MinDegree { get; set; }
        public int DepartmentId { get; set; }
        public Department Dept { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
        public ICollection<StuCrsRes> StudentCourse { get; set; }
    }
}
