using FixItApp.ApplicationCore;
using FixItApp.ApplicationCore.Interfaces;
using FixItApp.ApplicationCore.Mapping;
using FixItApp.ApplicationCore.Repositories;
using FixItApp.ApplicationCore.Services;
using FixItApp.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;

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
builder.Services.AddScoped<IApplicationRepository, ApplicationRepository>();
builder.Services.AddScoped<IFeedbackRepository, FeedbackRepository>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<IMapper, Mapper>();
builder.Services.AddScoped<IPasswordHashing, PasswordHashing>();

//adding auth
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(option =>
    {
        option.LoginPath = "/Access/LogIn";
        option.ExpireTimeSpan = TimeSpan.FromMinutes(10);
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireManagerRole", policy =>
    {
        policy.RequireClaim("Role", "Manager");
    });
    
    options.AddPolicy("RequireMasterRole", policy =>
    {
        policy.RequireClaim("Role", "Master");
    });
    
    options.AddPolicy("RequireCustomerRole", policy =>
    {
        policy.RequireClaim("Role", "Customer");
    });
});

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Access}/{action=LogIn}/{id?}");

app.Run();