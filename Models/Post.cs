using CommentAndReviewSystem1.Helpers;
using System.ComponentModel.DataAnnotations;

namespace CommentAndReviewSystem1.Models
{
    public partial class Post
    {
        public Post() { 
        Reviews= new HashSet<Review>();
        }

        public int PostId { get; set; }
        
        public Guid? UserId { get; set; }= Guid.Empty;

        [Display(Name = "Content Category")]
        public int? Category { get; set; }
        public DateTime AddingDate { get; set; } = DateTime.Now;

        
        public double? AverageRating { get; set; } = 0.0;

        public bool Status { get; set; }

        [Required]
        public string Content { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }



    }
}
