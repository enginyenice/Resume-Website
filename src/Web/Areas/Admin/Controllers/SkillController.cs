using AutoMapper;
using Business.Interfaces;
using DTO.DTOs.ExperienceDtos;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using DTO.DTOs.SkillDtos;

namespace Web.Areas.Admin.Controllers
{
 [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SkillController : Controller
    {
        private IGenericService<Skill> _skillGenericService;
        private IMapper _mapper;
        public SkillController(IGenericService<Skill> skillGenericService, IMapper mapper)
        {
            _skillGenericService = skillGenericService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            TempData["active"] = "yetenek";
            return View(_mapper.Map<List<SkillListDto>>(_skillGenericService.GetAll()));
        }

        public IActionResult Delete(int id)
        {
            TempData["active"] = "yetenek";
            var deletedEntity = _skillGenericService.GetById(id);
            _skillGenericService.Delete(deletedEntity);
            return RedirectToAction("Index");
        }

        public IActionResult Add()
        {
            TempData["active"] = "yetenek";
            return View(new SkillAddDto());
        }
        [HttpPost]
        public IActionResult Add(SkillAddDto model)
        {
            TempData["active"] = "yetenek";
            if (ModelState.IsValid)
            {
                _skillGenericService.Insert(_mapper.Map<Skill>(model));
                TempData["message"] = "İşleminiz başarıyla gerçekleşti";
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Update(int id)
        {
            TempData["active"] = "yetenek";
            SkillUpdateDto SkillUpdateDto =
                _mapper.Map<SkillUpdateDto>(_skillGenericService.GetById(id));
            return View(SkillUpdateDto);
        }

        [HttpPost]
        public IActionResult Update(SkillUpdateDto model)
        {
            TempData["active"] = "yetenek";
            if (ModelState.IsValid)
            {
                Skill updatedCertificate = _mapper.Map<Skill>(model);
                _skillGenericService.Update(updatedCertificate);
                TempData["message"] = "İşleminiz başarıyla gerçekleşti";
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
