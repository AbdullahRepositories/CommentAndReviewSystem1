using Microsoft.AspNetCore.Mvc;

namespace CommentAndReviewSystem1.Controllers
{
    public class PostController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
