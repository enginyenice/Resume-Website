using System.Collections.Generic;
using AutoMapper;
using Business.Interfaces;
using DTO.DTOs.EducationDtos;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Web.ViewComponents
{
	public class EducationComponent : ViewComponent
    {
        private IGenericService<Education> _genericService;
        private IMapper _mapper;

        public EducationComponent(IMapper mapper, IGenericService<Education> genericService)
        {
            _mapper = mapper;
            _genericService = genericService;
        }

        public IViewComponentResult Invoke()
        {

            return View(_mapper.Map<List<EducationListDto>>(_genericService.GetAll()));
        }
	}
}
