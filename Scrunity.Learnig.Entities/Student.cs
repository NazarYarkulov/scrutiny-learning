namespace Scrunity.Learnig.Entities
{
    public class Student
    {
        public int Id { get; set; }

        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; }
    }
}