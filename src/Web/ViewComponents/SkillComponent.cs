using System.Collections.Generic;
using AutoMapper;
using Business.Interfaces;
using DTO.DTOs.SkillDtos;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Web.ViewComponents
{
	public class SkillComponent : ViewComponent
    {
        private IGenericService<Skill> _genericService;
        private IMapper _mapper;

        public SkillComponent(IGenericService<Skill> genericService, IMapper mapper)
        {
            _genericService = genericService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {

            return View(_mapper.Map<List<SkillListDto>>(_genericService.GetAll()));
        }
	}
}
