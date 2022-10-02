using Business.Interfaces;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGenericService<Skill> _skillService;

        public HomeController(IGenericService<Skill> skillService)
        {
            _skillService = skillService;
        }

        public IActionResult Index()
        {
            return View(_skillService.GetAll());
        }
    }
}
