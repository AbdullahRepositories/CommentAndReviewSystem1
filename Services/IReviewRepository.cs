using CommentAndReviewSystem1.Models;

namespace CommentAndReviewSystem1.Services
{
    public interface IReviewRepository
    {
        public IEnumerable<Review> GetAll();
        public Review GetById(int id);
        public Review Add(Review review);
        public void Delete(int id);
    
       
        public Review Update(Review reviewchanges);

    }
}
