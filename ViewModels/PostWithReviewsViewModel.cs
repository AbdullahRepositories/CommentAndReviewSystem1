using CommentAndReviewSystem1.Models;
namespace CommentAndReviewSystem1.ViewModels
{
    public class PostWithReviewsViewModel
    {
    public Post post {  get; set; }
    public IEnumerable<Review> reviews { get; set; }

    }
}
