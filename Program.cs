using CommentAndReviewSystem1.Models;
using CommentAndReviewSystem1.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<PostingDBContext>(

    options => options.UseSqlServer(builder.Configuration.GetConnectionString("PostingDBContext")));
        builder.Services.AddScoped<IPostRepository, PostRepository>();
        builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddIdentity<IdentityUser, IdentityRole>(
               options => options.Password.RequireDigit = true
               ).
               AddEntityFrameworkStores<PostingDBContext>();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
