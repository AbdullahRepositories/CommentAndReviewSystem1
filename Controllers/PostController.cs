using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CommentAndReviewSystem1.Services;
using CommentAndReviewSystem1.Models;

namespace CommentAndReviewSystem1.Controllers
{
    public class PostController : Controller
    {

        private readonly IPostRepository _postRepository;


        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }



        [HttpGet]
        public async Task<IActionResult> AddPost()
        {
            
            
           
            //var user = await _userManager.GetUserAsync(User);
            //if (user != null && await _userManager.IsInRoleAsync(user, "Instructor"))
            //{
            //    var instructorName = $"{user.FirstName} {user.LastName}";
            //    ViewBag.InstructorName = instructorName;
            //}

            


            return View();
        }


        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult AddPost(Post model)
        {

            
                if (ModelState.IsValid)
                {
                    Post newPost = new()
                    {
                        Content = model.Content,
                        Category = model.Category.Value,
                        AddingDate = DateTime.Now,
                        Status    = model.Status,
                        UserId= model.UserId,
                    };
                    _postRepository.Add(newPost);
                _postRepository.Save();
                }
                return View();
            
        }
    }
}
