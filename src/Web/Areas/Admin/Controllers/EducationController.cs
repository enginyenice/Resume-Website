using AutoMapper;
using Business.Interfaces;
using DTO.DTOs.EducationDtos;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;

namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class EducationController : Controller
    {
        private IGenericService<Education> _educationGenericService;
        private IMapper _mapper;
        public EducationController(IGenericService<Education> educationGenericService, IMapper mapper)
        {
            _educationGenericService = educationGenericService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            TempData["active"] = "egitim";
            return View(_mapper.Map<List<EducationListDto>>(_educationGenericService.GetAll()));
        }

        public IActionResult Delete(int id)
        {
            TempData["active"] = "egitim";
            var deletedEntity = _educationGenericService.GetById(id);
            _educationGenericService.Delete(deletedEntity);
            return RedirectToAction("Index");
        }

        public IActionResult Add()
        {
            TempData["active"] = "egitim";
            return View(new EducationAddDto());
        }
        [HttpPost]
        public IActionResult Add(EducationAddDto model)
        {
            TempData["active"] = "egitim";
            if (ModelState.IsValid)
            {
                _educationGenericService.Insert(_mapper.Map<Education>(model));
                TempData["message"] = "İşleminiz başarıyla gerçekleşti";
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Update(int id)
        {
            TempData["active"] = "egitim";
            EducationUpdateDto EducationUpdateDto =
                _mapper.Map<EducationUpdateDto>(_educationGenericService.GetById(id));
            return View(EducationUpdateDto);
        }

        [HttpPost]
        public IActionResult Update(EducationUpdateDto model)
        {
            TempData["active"] = "egitim";
            if (ModelState.IsValid)
            {
                Education updatedCertificate = _mapper.Map<Education>(model);
                _educationGenericService.Update(updatedCertificate);
                TempData["message"] = "İşleminiz başarıyla gerçekleşti";
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
