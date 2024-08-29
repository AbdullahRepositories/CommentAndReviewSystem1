using CommentAndReviewSystem1.Helpers;
using System.ComponentModel.DataAnnotations;

namespace CommentAndReviewSystem1.Models
{
    public partial class Post
    {
        public Post() { }

        public int PostId { get; set; }
        
        public Guid? UserId { get; set; }

        [Display(Name = "Content Category")]
        public Category? Category { get; set; }
        public DateTime AddingDate { get; set; } = DateTime.Now;

        
        public double? AverageRating { get; set; } = 0.0;

        public bool Status { get; set; }

        [Required]
        public string Content { get; set; }
        public virtual ICollection<Review> Reviews { get; set; } = new HashSet<Review>();



    }
}
