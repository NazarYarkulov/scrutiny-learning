namespace Scrunity.Learnig.Entities
{
    public class Test
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int SuccessfulRating { get; set; }
        public int RetryCount { get; set; }

        public int ArticleId { get; set; }
        public Article Article { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}
