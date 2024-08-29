using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CommentAndReviewSystem1.Services;

namespace CommentAndReviewSystem1.Controllers
{
    public class PostController : Controller
    {

        private readonly IPostRepository _postRepository;


        public PostController()
        {

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


        //[ValidateAntiForgeryToken]
        //[HttpPost]
        //public IActionResult AddPost( model)
        //{
        //    string uniqeFileName = ProcessUploadFile(model, x => x.Picture);

        //    //string uniqeFileName = ProcessUploadFile(model);
        //    //ViewBag.Categories = _context.Categories;
        //    //ViewBag.Languages = _context.Languages;

        //    string idToSave = null;
        //    bool _status = true;
        //    bool _claim = true;

        //    if (User.IsInRole("Student") || User.IsInRole("Admin"))
        //    {
        //        idToSave = model.AddedByUserId;

        //    }
        //    else if (User.IsInRole("Instructor"))
        //    {
        //        idToSave = model.InstructorId;
        //        model.Status = _status;
        //        model.Claimed = _claim;

        //    }
        //    if (ModelState.IsValid && idToSave != null)
        //    {
        //        Course newCourse = new()
        //        {
        //            Title = model.Title,
        //            AddedByUserId = model.AddedByUserId,
        //            CategoryId = model.CategoryId,
        //            AddingDate = model.AddingDate,
        //            AverageRating = model.AverageRating,
        //            LastUpdate = model.LastUpdate,
        //            InstructorFullName = model.InstructorFullName,
        //            CourseDuration = model.CourseDuration,
        //            CourseDescription = model.CourseDescription,
        //            LanguageId = model.LanguageId,
        //            Level = model.Level,
        //            PriceStatus = model.PriceStatus,
        //            SubcategoryId = model.SubcategoryId,
        //            TopicsCovered = model.TopicsCovered,
        //            Link = model.Link,
        //            VedioLength = model.VedioLength,
        //            Picture = uniqeFileName,
        //            Status = model.Status,
        //            Platform = model.Platform,
        //            InstructorId = model.InstructorId,
        //            Claimed = model.Claimed,

        //        };
        //        _courseRepository.Add(newCourse);
        //        _courseRepository.Save();

        //        TempData["Success"] = "Course added successfully!";
        //        return RedirectToAction("index", "instructor");
        //    }
        //    var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
        //    return RedirectToAction("addcourse", "instructor");
        //}
    }
}
