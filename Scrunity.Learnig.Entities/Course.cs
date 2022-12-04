namespace Scrunity.Learnig.Entities
{
    public class Course
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Level { get; set; }
        public string Specialization { get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}