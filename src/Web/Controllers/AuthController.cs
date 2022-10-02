using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Business.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class AuthController : Controller
    {
        private IAppUserService _appUserService;

        public AuthController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        public IActionResult Login()
        {
            return View(new AppUserLoginModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(AppUserLoginModel loginModel)
        {
            if(ModelState.IsValid)
            {
                if (_appUserService.CheckUser(loginModel.UserName, loginModel.Password))
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, loginModel.UserName),
                        new Claim(ClaimTypes.Role, "Admin")
                    };

                    var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties()
                    {
                        IsPersistent = true
                    };
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimIdentity), authProperties);
                    return RedirectToAction("Index", "Home", new { @area = "Admin" });
                }
                ModelState.AddModelError("","Kullanıcı adı veya şifre yanlış.");
            }
            return View(new AppUserLoginModel());
        }

        public async  Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home", new { @area = "" });
        }
    }
}
