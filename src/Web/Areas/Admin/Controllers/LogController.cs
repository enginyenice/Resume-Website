using AutoMapper;
using Business.Interfaces;
using DTO.DTOs.LogDtos;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;

namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class LogController : Controller
	{
		private readonly IGenericService<Log> _genericService;
		private readonly IMapper _mapper;
		public LogController(IGenericService<Log> genericService, IMapper mapper)
		{
			_genericService = genericService;
			_mapper = mapper;
		}

		public IActionResult Index()
		{
            TempData["active"] = "log";
            return View(_mapper.Map<List<LogListDto>>(_genericService.GetAll()));
		}
	}
}
