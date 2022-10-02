using AutoMapper;
using Business.Interfaces;
using DTO.DTOs.AppUserDtos;
using Microsoft.AspNetCore.Mvc;

namespace Web.ViewComponents
{
	public class NavbarComponent : ViewComponent
    {
        private IAppUserService _appUserService;
        private IMapper _mapper;

        public NavbarComponent(IAppUserService appUserService, IMapper mapper)
        {
            _appUserService = appUserService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            return View(_mapper.Map<AppUserListDto>(_appUserService.GetById(1)));
        }
	}
}
