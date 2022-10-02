using AutoMapper;
using Business.Interfaces;
using DTO.DTOs.CertificationDtos;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using DTO.DTOs.SocialMediaIconDtos;

namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SocialMediaIconController : Controller
    {
        private ISocialMediaIconService _socialMediaIconService;
        private IAppUserService _userService;
        private IMapper _mapper;

        public SocialMediaIconController(ISocialMediaIconService socialMediaIconService, IMapper mapper, IAppUserService userService)
        {
            _socialMediaIconService = socialMediaIconService;
            _mapper = mapper;
            _userService = userService;
        }

        public IActionResult Index()
        {
            TempData["active"] = "sosyal";
            return View(_mapper.Map<List<SocialMediaIconListDto>>(_socialMediaIconService.GetAll()));
        }

        public IActionResult Add()
        {
            TempData["active"] = "sosyal";
            return View(new SocialMediaIconAddDto());
        }

        [HttpPost]
        public IActionResult Add(SocialMediaIconAddDto model)
        {
            TempData["active"] = "sosyal";
            if (ModelState.IsValid)
            {
                SocialMediaIcon addSocialMediaIcon = _mapper.Map<SocialMediaIcon>(model);
                addSocialMediaIcon.AppUserId = _userService.FindByUserName(User.Identity.Name).Id;
                _socialMediaIconService.Insert(addSocialMediaIcon);
                TempData["message"] = "İşleminiz başarıyla gerçekleşti";
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            TempData["active"] = "sosyal";
            var deletedEntity = _socialMediaIconService.GetById(id);
            _socialMediaIconService.Delete(deletedEntity);
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            TempData["active"] = "sosyal";
            SocialMediaIconUpdateDto socialMediaIconUpdateDto =
                _mapper.Map<SocialMediaIconUpdateDto>(_socialMediaIconService.GetById(id));
            return View(socialMediaIconUpdateDto);
        }

        [HttpPost]
        public IActionResult Update(SocialMediaIconUpdateDto model)
        {
            TempData["active"] = "sosyal";
            if (ModelState.IsValid)
            {
                SocialMediaIcon updatedSocialMediaIcon = _mapper.Map<SocialMediaIcon>(model);
                updatedSocialMediaIcon.AppUserId = _userService.FindByUserName(User.Identity.Name).Id; 
                _socialMediaIconService.Update(updatedSocialMediaIcon);
                TempData["message"] = "İşleminiz başarıyla gerçekleşti";
                return RedirectToAction("Index");
            }
            return View(model);
        }

    }
}
