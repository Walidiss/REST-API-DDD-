using HomeKitchen.Api;
using HomeKitchen.Api.Common.Errors;
using HomeKitchen.Application;
using HomeKitchen.Infrastructure;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

{
    // Add services to the container.
    builder.Services
        .AddApplication()
        .AddPresentation()
        .AddInfrastructure(builder.Configuration);
  //  builder.Services
  //.ConfigureApplicationCookie(options =>
  // {
  //     options.Cookie.Name = ".AspNetCore.Cookies";
  //     options.Cookie.HttpOnly = true;
  //     options.Cookie.Expiration = TimeSpan.FromDays(150);
  //     options.LoginPath = "/Account/Login"; // If the LogoutPath is not set here, ASP.NET Core will default to /Account/Logout
  //     options.SlidingExpiration = true;
  //     options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
  // });
}

var app = builder.Build();
{
    app.UseAuthentication();
    app.UseAuthorization();
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();

    app.MapControllers();
    app.Run();
}


