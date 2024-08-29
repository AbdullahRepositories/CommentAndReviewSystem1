namespace CommentAndReviewSystem1.Models
{
    public partial class Post
    {
        public Post() { }

        public int PostId { get; set; }
        public int CategoryId { get; set; }
        public string? UserId { get; set; }
        public DateTime AddingDate { get; set; } = DateTime.Now;

        public double? AverageRating { get; set; } = 0.0;

        public bool Status { get; set; }

        public string Content { get; set; }
        public virtual ICollection<Review> Reviews { get; set; } = new HashSet<Review>();



    }
}
