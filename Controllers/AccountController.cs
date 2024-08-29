using Microsoft.AspNetCore.Mvc;

namespace CommentAndReviewSystem1.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
