using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MovieReviewApp;
using MovieReviewApp.Areas.Admin.Interfaces;
using MovieReviewApp.Areas.Admin.Repositories;
using MovieReviewApp.Data;
using MovieReviewApp.Interfaces;
using MovieReviewApp.Models;
using MovieReviewApp.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<Seed>();
builder.Services.AddDbContext<ApplicationDbContext>(options =>

    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.Password.RequireDigit= true;
    options.Password.RequireUppercase= true;
    options.Password.RequireLowercase= true;
    options.Password.RequireNonAlphanumeric= false;
    options.Password.RequiredLength = 8;
}).AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddScoped<IMovieRepository,MovieRepository>();
builder.Services.AddScoped<IGenreRepository,GenreRepository>();
builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddScoped<MovieReviewApp.Areas.Admin.Interfaces.IActorRepository, MovieReviewApp.Areas.Admin.Repositories.ActorRepository>();
builder.Services.AddScoped<MovieReviewApp.Interfaces.IActorRepository, MovieReviewApp.Repositories.ActorRepository>();
builder.Services.AddScoped<MovieReviewApp.Areas.Admin.Interfaces.ICommentRepository, MovieReviewApp.Areas.Admin.Repositories.CommentRepository>();
builder.Services.AddScoped<MovieReviewApp.Interfaces.ICommentRepository, MovieReviewApp.Repositories.CommentRepository>();

builder.Services.ConfigureApplicationCookie(options =>
{
    // Cookie settings
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);

    options.LoginPath = "/Account/Login";
    //options.AccessDeniedPath = "/Identity/Account/AccessDenied";
    options.SlidingExpiration = true;
});

var app = builder.Build();

SeedData(app);

async void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<Seed>();
        await service.SeedDataContext();
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Account}/{action=Login}/{id?}");

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Account}/{action=Login}/{id?}");
});
app.UseStaticFiles();

app.Run();
