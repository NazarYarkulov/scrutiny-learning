namespace Scrunity.Learnig.Entities
{
    public class Article
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Text { get; set; }
        public ICollection<string> VideoLinks { get; set; }
        public ICollection<string> ImagesLinks { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
        public Test Test { get; set; }
    }
}
