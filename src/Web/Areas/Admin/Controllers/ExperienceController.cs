using AutoMapper;
using Business.Interfaces;
using DTO.DTOs.EducationDtos;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using DTO.DTOs.ExperienceDtos;

namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ExperienceController : Controller
    {
        private IGenericService<Experience> _experienceGenericService;
        private IMapper _mapper;
        public ExperienceController(IGenericService<Experience> experienceGenericService, IMapper mapper)
        {
            _experienceGenericService = experienceGenericService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            TempData["active"] = "deneyim";
            return View(_mapper.Map<List<ExperienceListDto>>(_experienceGenericService.GetAll()));
        }

        public IActionResult Delete(int id)
        {
            TempData["active"] = "deneyim";
            var deletedEntity = _experienceGenericService.GetById(id);
            _experienceGenericService.Delete(deletedEntity);
            return RedirectToAction("Index");
        }

        public IActionResult Add()
        {
            TempData["active"] = "deneyim";
            return View(new ExperienceAddDto());
        }
        [HttpPost]
        public IActionResult Add(ExperienceAddDto model)
        {
            TempData["active"] = "deneyim";
            if (ModelState.IsValid)
            {
                _experienceGenericService.Insert(_mapper.Map<Experience>(model));
                TempData["message"] = "İşleminiz başarıyla gerçekleşti";
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Update(int id)
        {
            TempData["active"] = "deneyim";
            ExperienceUpdateDto ExperienceUpdateDto =
                _mapper.Map<ExperienceUpdateDto>(_experienceGenericService.GetById(id));
            return View(ExperienceUpdateDto);
        }

        [HttpPost]
        public IActionResult Update(ExperienceUpdateDto model)
        {
            TempData["active"] = "deneyim";
            if (ModelState.IsValid)
            {
                Experience updatedCertificate = _mapper.Map<Experience>(model);
                _experienceGenericService.Update(updatedCertificate);
                TempData["message"] = "İşleminiz başarıyla gerçekleşti";
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
