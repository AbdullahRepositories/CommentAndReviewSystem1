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





        public IActionResult Register()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {

                IdentityUser userModel = new();
                userModel.Email = model.Email;
                userModel.PasswordHash = model.Password;
                userModel.UserName = model.Email;
                IdentityResult result = await _userManager.CreateAsync(userModel, model.Password);

                if (result.Succeeded == true)
                {

                    await _signInManager.SignInAsync(userModel, isPersistent: false);
                    TempData["Success"] = "Account created successfully!";
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    //List<KeyValuePair<string, string>> erorrs = new List<KeyValuePair<string, string>>();
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                        //erorrs.Add(new KeyValuePair<string, string>("", item.Description));
                    }


                }
                
            }
            return View(model);

        }





            public async Task<IActionResult> Logout()
            {
                // Sign out the user
                await _signInManager.SignOutAsync();

                // Clear authentication cookies
                Response.Cookies.Delete(".AspNetCore.Identity.Application");

                // Optionally, clear session
                HttpContext.Session.Clear();

                // Redirect to home page
                return RedirectToAction("Index", "Home");
            }
        }
    }

