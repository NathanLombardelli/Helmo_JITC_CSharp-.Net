using JITC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("JITCDbContextConnection") ?? throw new InvalidOperationException("Connection string 'JITCDbContextConnection' not found.");

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddMvc(options => options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute())); // plus besoin de [ValidateAntiforgeryToken] les méthodes.



builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizePage("/Profile");
    options.Conventions.AuthorizePage("/Vol");
    options.Conventions.AuthorizeFolder("/Admin", "Admin"); //claims admin
    options.Conventions.AuthorizeFolder("/Pilote", "Pilote"); //claims Pilote
});


//builder.Services.AddDbContext<JITCDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddDbContext<JITCDbContext>();


builder.Services.AddAuthentication().AddCookie(config => { config.Cookie.Name = "ConnectionCookie"; config.LoginPath = "/Identity/Account/Login"; });


builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 3;
}).AddDefaultUI().AddEntityFrameworkStores<JITCDbContext>();



var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();

app.UseStaticFiles(
    new StaticFileOptions
    {
        OnPrepareResponse = ctx =>
{
    const int durationInSecond = 60 * 60 * 24;
    ctx.Context.Response.Headers[HeaderNames.CacheControl] = "public,max-age=" + durationInSecond;
}
    });

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
