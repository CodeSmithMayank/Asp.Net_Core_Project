// From where programs starts
using Asp.Net_Core_Project.Models;

var builder = WebApplication.CreateBuilder(args);

//This we are using becuase to add all required mvc services to a dependency injection container
builder.Services.AddMvc();

//To add services to asp.net core dependency injection container 
// AddSingleton method we use to add out services to asp.net core dependency injection container , to add our dependency to dependency injection container
// We have to register our IEmployeeRepository interface & MockEmployeeRepository in dependency injection container

builder.Services.AddSingleton<IEmployeeRepository , MockEmployeeRepository>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//To add static files
//app.UseStaticFiles();

//To use default files
//app.UseDefaultFiles();

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

// Mvc middleware to configure request which comes through pipeline , this means it will go to by default controller which is Home & Index is method inside it
// One of the main important thing request comes through each middleware and execure through specific middleware and return from there only
//app.UseMvcWithDefaultRoute();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
