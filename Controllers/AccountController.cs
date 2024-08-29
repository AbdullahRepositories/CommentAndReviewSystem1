using CommentAndReviewSystem1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using CommentAndReviewSystem1.ViewModels;
namespace CommentAndReviewSystem1.Controllers
{
    
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                IdentityUser userModel = await _userManager.FindByEmailAsync(login.Email);
                bool found = await _userManager.CheckPasswordAsync(userModel, login.Password);

                if (userModel != null && found)
                {

                    //bool found = await _userManager.CheckPasswordAsync(userModel, login.Password);
                   
                    
                    
                        await _signInManager.SignInAsync(userModel, login.RememberMe);
                        return RedirectToAction("Index", "Home");
                    
                    

                }
                else { ModelState.AddModelError("", "Eeither Email or Password is invalid"); }

            }
            return View(login);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
