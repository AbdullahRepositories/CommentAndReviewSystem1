using CommentAndReviewSystem1.Models;
using Microsoft.EntityFrameworkCore;

namespace CommentAndReviewSystem1.Services
{
    public interface IPostRepository
    {


        public IEnumerable<Post> GetAll();
        public Post GetById(int id);
        public void Delete(int id);
        public Post Add(Post post);
        public bool Save();
        public Post Update(Post postChanges);


    }
}
