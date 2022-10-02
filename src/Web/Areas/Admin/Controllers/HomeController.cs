using System;
using System.IO;
using Business.Interfaces;
using DTO.DTOs.AppUserDtos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Web.Models;

namespace Web.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Admin")]
	public class HomeController : Controller
    {
        private IAppUserService _userService;

        public HomeController(IAppUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            TempData["active"] = "bilgilerim";
            var userName = User.Identity.Name;
            var user = _userService.FindByUserName(userName);
            AppUserUpdateModel appUserListDto = new AppUserUpdateModel()
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Address = user.Address,
                ImageUrl = user.ImageUrl,
                Id = user.Id,
                ShortDescription = user.ShortDescription
            };

			return View(appUserListDto);
		}

        [HttpPost]
        public IActionResult Index(AppUserUpdateModel model)
        {
            TempData["active"] = "bilgilerim";
            if (ModelState.IsValid)
            {
                var appUserUpdateModel = _userService.GetById(model.Id);
                if (model.Picture != null)
                {
                    var imgName = Guid.NewGuid() + Path.GetExtension(model.Picture.FileName);
                    var path = Directory.GetCurrentDirectory() + "/wwwroot/img/" + imgName;
                    var stream = new FileStream(path, FileMode.Create);
                    model.Picture.CopyTo(stream);
                    appUserUpdateModel.ImageUrl = imgName;
                }

                appUserUpdateModel.FirstName = model.FirstName;
                appUserUpdateModel.LastName = model.LastName;
                appUserUpdateModel.ShortDescription = model.ShortDescription;
                appUserUpdateModel.Address = model.Address;
                appUserUpdateModel.Email = model.Email;


                _userService.Update(appUserUpdateModel);
                TempData["message"] = "İşleminiz başarıyla gerçekleşti";
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult ChangePassword()
        {
            var user = _userService.FindByUserName(User.Identity.Name);
            


            TempData["active"] = "sifre";
            return View(new AppUserForPasswordDto()
            {
                Id = user.Id
            });
        }

        [HttpPost]
        public IActionResult ChangePassword(AppUserForPasswordDto model)
        {
            TempData["active"] = "sifre";

            if (ModelState.IsValid)
            {
                var updatedUser = _userService.FindByUserName(User.Identity.Name);
                updatedUser.Password = model.Password;
                _userService.Update(updatedUser);
                HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }

            return View(model);
        }
	}
}
