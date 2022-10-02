using AutoMapper;
using Business.Interfaces;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using static Web.Models.LogResponseModel;

namespace Web.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LogController : ControllerBase
	{
		private readonly IGenericService<Log> _genericService;
		private readonly IMapper _mapper;

		public LogController(IGenericService<Log> genericService, IMapper mapper)
		{
			_genericService = genericService;
			_mapper = mapper;
		}

		[HttpPost]
        public Task Add(LogResponseDto model)
		{
            Log log = new Log()
            {
                City = model.city,
                Date = DateTime.Now,
                Ip = model.ip,
                Org = model.org,
                Region = model.region
            };
            _genericService.Insert(log);
			return Task.CompletedTask;
		}

	}
}
