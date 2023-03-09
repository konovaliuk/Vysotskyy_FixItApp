using FixItApp.ApplicationCore;
using FixItApp.ApplicationCore.Interfaces;
using FixItApp.ApplicationCore.Mapping;
using FixItApp.ApplicationCore.Repositories;
using FixItApp.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var connectionString = builder.Configuration["DBConnectionString"];
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString ,  new MySqlServerVersion(new Version(8, 0, 11)),
        b => b.MigrationsAssembly("FixItApp.Infrastructure")));

//adding Mediatr
builder.Services.AddFixItAppApplication();

//adding Dependency injection
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IMapper, Mapper>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();