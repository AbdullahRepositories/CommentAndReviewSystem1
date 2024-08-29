namespace CommentAndReviewSystem1.Models
{
    public partial class Review
    {
        public Review() { }

        public int ReviewId { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public byte Rating { get; set; }

        public DateTime ReviewingDate { get; set; } = DateTime.Now;
        public Guid UserId { get; set; }
        public int PostId { get; set; }

        public virtual Post Post { get; set; }
        //public virtual User User { get; set; }


    }
}
