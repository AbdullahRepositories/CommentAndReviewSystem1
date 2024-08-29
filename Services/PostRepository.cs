using CommentAndReviewSystem1.Models;

namespace CommentAndReviewSystem1.Services
{
    public class PostRepository:IPostRepository
    {
        private readonly PostingDBContext _context;

        public PostRepository(PostingDBContext context)
        {
            _context=context;
        }

        public Post Add(Post post)
        {
            if (post is null)
            {
                throw new ArgumentNullException(nameof(post));
            }
            _context.Posts.Add(post);
            //_context.SaveChanges();
            return post;
        }


        public void Delete(int id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var Post = _context.Posts.FirstOrDefault(C => C.PostId == id);

            _context.Posts.Remove(Post);
        }
        public Post GetById(int id)
        {
            if (id == 0)
            {
                throw new ArgumentNullException(nameof(id));
            }
            return _context.Posts.FirstOrDefault(C => C.PostId == id);
        }
        public IEnumerable<Post> GetAll()
        {
            return _context.Posts;
        }
        public IEnumerable<Post> GetAllExcepted()
        {
            return _context.Posts.Where(c => c.Status == true);
        }


        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
        //public IEnumerable<Post> GetPostsByCategory(int Category)
        //{
        //    return throw;


        //    //return _context.Posts.Where(C => C.Category.Value == Category).Include(C => C.Reviews);
        //}
    }
}
