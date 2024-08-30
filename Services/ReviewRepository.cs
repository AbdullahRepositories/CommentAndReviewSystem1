using CommentAndReviewSystem1.Models;
using Microsoft.EntityFrameworkCore;

namespace CommentAndReviewSystem1.Services
{
    public class ReviewRepository:IReviewRepository
    {
        private readonly PostingDBContext _context;
        public ReviewRepository(PostingDBContext Context)
        {
            _context = Context;
        }

        public Review Add(Review review)
        {
            _context.Add(review);
            //_context.SaveChanges();
            return review;
        }

        public void Delete(int id)
        {
            Review review = GetById(id);
            _context.Reviews.Remove(review);
            _context.SaveChanges();

        }

        public IEnumerable<Review> GetAll()
        {
            return _context.Reviews;
        }

        public Review GetById(int id)
        {
            return _context.Reviews.FirstOrDefault(R => R.ReviewId == id);
        }
        public IEnumerable<Review> GetByPost(int id)
        {
            return _context.Reviews.Where(R => R.PostId == id);
        }

        public Review Update(Review reviewchanges)
        {
            var _review = _context.Reviews.Attach(reviewchanges);
            _review.State = EntityState.Modified;
            return reviewchanges;
        }
        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
