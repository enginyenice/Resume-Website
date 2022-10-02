using AutoMapper;
using Business.Interfaces;
using DTO.DTOs.InterestDtos;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Web.ViewComponents
{
	public class InterestComponent : ViewComponent
    {
        private IGenericService<Interest> _genericService;
        private IMapper _mapper;

        public InterestComponent(IGenericService<Interest> genericService, IMapper mapper)
        {
            _genericService = genericService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {

            return View(_mapper.Map<List<InterestListDto>>(_genericService.GetAll()));
        }
	}
}
