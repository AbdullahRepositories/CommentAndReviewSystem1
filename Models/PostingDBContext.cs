using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CommentAndReviewSystem1.Models
{

    public partial class PostingDBContext : IdentityDbContext<IdentityUser>
    {
        public PostingDBContext()
        {
        }
        public PostingDBContext(DbContextOptions<PostingDBContext> options) : base(options) { }

        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
    }
}
    
