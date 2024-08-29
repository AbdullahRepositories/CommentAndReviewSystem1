using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CommentAndReviewSystem1.Services;
using CommentAndReviewSystem1.Models;
using System;
using Microsoft.AspNetCore.Authorization;

namespace CommentAndReviewSystem1.Controllers
{

    //[Authorize]
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
                        Title= model.Title,
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
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Post post = _postRepository.GetById(id);
            if (post == null)
            {
                return NotFound();
            }

                
            

            return View(post);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Post model)
        {
            //throw new Exception(" in edit exiption");
            if (ModelState.IsValid)
            {
                Post post = _postRepository.GetById(model.PostId);
                post.Title = model.Title;
                post.Content = model.Content;
                post.Category = model.Category.Value;
                

                _postRepository.Update(post);
                _postRepository.Save();
                TempData["message"] = "Edited Successfully:)";
                return RedirectToAction("Index","home");

            }
            return View();
        }

        public IActionResult Details(int postId)
        {
            var post = _postRepository.GetById(postId);

                //ViewBag.SuccessMessage = TempData["SuccessMessage"];

                
                return View(post);
            
        }
    }
}
