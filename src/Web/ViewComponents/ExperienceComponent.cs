using System.Collections.Generic;
using AutoMapper;
using Business.Interfaces;
using DTO.DTOs.ExperienceDtos;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Web.ViewComponents
{
	public class ExperienceComponent : ViewComponent
    {
        private IGenericService<Experience> _genericExperienceService;
        private IMapper _mapper;

        public ExperienceComponent(IGenericService<Experience> genericExperienceService, IMapper mapper)
        {
            _genericExperienceService = genericExperienceService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            
            return View(_mapper.Map<List<ExperienceListDto>>(_genericExperienceService.GetAll()));
        }
	}
}
