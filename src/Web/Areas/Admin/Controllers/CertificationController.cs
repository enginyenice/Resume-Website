using System.Collections.Generic;
using AutoMapper;
using Business.Interfaces;
using DTO.DTOs.CertificationDtos;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CertificationController : Controller
    {
        private IGenericService<Certification> _certificationGenericService;
        private IMapper _mapper;
        public CertificationController(IGenericService<Certification> certificationGenericService, IMapper mapper)
        {
            _certificationGenericService = certificationGenericService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            TempData["active"] = "sertifika";
            return View(_mapper.Map<List<CertificationListDto>>(_certificationGenericService.GetAll()));
        }

        public IActionResult Delete(int id)
        {
            TempData["active"] = "sertifika";
            var deletedEntity = _certificationGenericService.GetById(id);
            _certificationGenericService.Delete(deletedEntity);
            return RedirectToAction("Index");
        }

        public IActionResult Add()
        {
            TempData["active"] = "sertifika";
            return View(new CertificationAddDto());
        }
        [HttpPost]
        public IActionResult Add(CertificationAddDto model)
        {
            TempData["active"] = "sertifika";
            if (ModelState.IsValid)
            {
                _certificationGenericService.Insert(_mapper.Map<Certification>(model));
                TempData["message"] = "İşleminiz başarıyla gerçekleşti";
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Update(int id)
        {
            TempData["active"] = "sertifika";
            CertificationUpdateDto certificationUpdateDto =
                _mapper.Map<CertificationUpdateDto>(_certificationGenericService.GetById(id));
            return View(certificationUpdateDto);
        }

        [HttpPost]
        public IActionResult Update(CertificationUpdateDto model)
        {
            TempData["active"] = "sertifika";
            if (ModelState.IsValid)
            {
                Certification updatedCertificate = _mapper.Map<Certification>(model);
                _certificationGenericService.Update(updatedCertificate);
                TempData["message"] = "İşleminiz başarıyla gerçekleşti";
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
