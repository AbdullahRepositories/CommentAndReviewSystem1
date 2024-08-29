using CommentAndReviewSystem1.Services;
using Microsoft.AspNetCore.Mvc;
using CommentAndReviewSystem1.Services;
using CommentAndReviewSystem1.Models;
using Microsoft.AspNetCore.Identity;

namespace CommentAndReviewSystem1.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewRepository _reviewRepository;


        public ReviewController(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }


        [HttpGet]
        public IActionResult AddReview(int postId)
        {
            
            //var UserId = _userManager.GetUserId(User);
            //var existingReview = _reviewRepository.GetAll()
            //.FirstOrDefault(r => r.PostId == Id && r.UserId == UserId);
            //if (existingReview != null)
            //{
            //    TempData["Failed"] = "You have already added a review for this course!!";

            //    return RedirectToAction("Details", "Course", new { id = Id });
            //}

            var model = new Review
            {
                PostId = postId,
                //UserId = UserId,
            };
            return View(model);


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddReview(Review model)
        {
            

            if (ModelState.IsValid)
            {
                Review review = new()
                {
                    Description = model.Description,
                    Rating = model.Rating,
                   
                    PostId = model.PostId,
                    UserId = model.UserId,

                };

                _reviewRepository.Add(review);
                _reviewRepository.Save();
                TempData["message"] = "Review added successfully!";
                return RedirectToAction("Details", "Post", new { postId = model.PostId });
            }
            // return RedirectToAction("Details", new { id = review.ReviewId });
            return RedirectToAction("Index", "Home");

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
