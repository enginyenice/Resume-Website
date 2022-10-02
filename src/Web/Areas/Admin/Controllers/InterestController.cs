using AutoMapper;
using Business.Interfaces;
using DTO.DTOs.EducationDtos;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using DTO.DTOs.InterestDtos;

namespace Web.Areas.Admin.Controllers
{
	[Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class InterestController : Controller
    {
        private IGenericService<Interest> _interestGenericService;
        private IMapper _mapper;
        public InterestController(IGenericService<Interest> interestGenericService, IMapper mapper)
        {
            _interestGenericService = interestGenericService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            TempData["active"] = "hobi";
            return View(_mapper.Map<List<InterestListDto>>(_interestGenericService.GetAll()));
        }

        public IActionResult Delete(int id)
        {
            TempData["active"] = "hobi";
            var deletedEntity = _interestGenericService.GetById(id);
            _interestGenericService.Delete(deletedEntity);
            return RedirectToAction("Index");
        }

        public IActionResult Add()
        {
            TempData["active"] = "hobi";
            return View(new InterestAddDto());
        }
        [HttpPost]
        public IActionResult Add(InterestAddDto model)
        {
            TempData["active"] = "hobi";
            if (ModelState.IsValid)
            {
                _interestGenericService.Insert(_mapper.Map<Interest>(model));
                TempData["message"] = "İşleminiz başarıyla gerçekleşti";
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Update(int id)
        {
            TempData["active"] = "hobi";
            InterestUpdateDto InterestUpdateDto =
                _mapper.Map<InterestUpdateDto>(_interestGenericService.GetById(id));
            return View(InterestUpdateDto);
        }

        [HttpPost]
        public IActionResult Update(InterestUpdateDto model)
        {
            TempData["active"] = "hobi";
            if (ModelState.IsValid)
            {
                Interest updatedCertificate = _mapper.Map<Interest>(model);
                _interestGenericService.Update(updatedCertificate);
                TempData["message"] = "İşleminiz başarıyla gerçekleşti";
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
