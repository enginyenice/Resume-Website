using System.Collections.Generic;
using AutoMapper;
using Business.Interfaces;
using DTO.DTOs.CertificationDtos;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Web.ViewComponents
{
    public class CertificationComponent : ViewComponent
    {
        private IGenericService<Certification> _genericService;
        private IMapper _mapper;

        public CertificationComponent(IMapper mapper, IGenericService<Certification> genericService)
        {
            _mapper = mapper;
            _genericService = genericService;
        }

        public IViewComponentResult Invoke()
        {

            return View(_mapper.Map<List<CertificationListDto>>(_genericService.GetAll()));
        }
    }
}
