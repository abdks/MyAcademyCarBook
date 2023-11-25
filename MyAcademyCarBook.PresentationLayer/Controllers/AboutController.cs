using FluentValidation.Validators;
using Microsoft.AspNetCore.Mvc;
using MyAcademyCarBook.BusinessLayer.Abstract;
using MyAcademyCarBook.EntityLayer.Concrete;

namespace MyAcademyCarBook.PresentationLayer.Controllers
{
    public class AboutController : Controller
    {
        private readonly IAbouttService _abouttService;
        private readonly IAboutDService _aboutDService;

        public AboutController(IAbouttService abouttService, IAboutDService aboutDService)
        {
            _abouttService = abouttService;
            _aboutDService = aboutDService;
        }
        public class CombinedDataViewModel
        {
            public IEnumerable<Team> TeamValues { get; set; }
            public IEnumerable<About> AboutValues { get; set; }
        }

        public IActionResult Index()
        {
            //var values = _abouttService.TGetListAll();
            //return View(values);
            var teamValues = _abouttService.TGetListAll();
            var aboutValues = _aboutDService.TGetListAll();

            // Combine the data from both services as needed
            var combinedData = new CombinedDataViewModel
            {
                TeamValues = teamValues,
                AboutValues = aboutValues
            };

            return View(combinedData);
        }

        public IActionResult AdminIndex()
        {
            var values = _abouttService.TGetListAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddAbout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAbout(Team team)
        {
            _abouttService.TInsert(team);
            return RedirectToAction("AdminIndex");
        }

        public IActionResult DeleteAbout(int id)
        {
            var value = _abouttService.TGetById(id);
            _abouttService.TDelete(value);
            return RedirectToAction("AdminIndex");
        }

        [HttpGet]
        public IActionResult UpdateAbout(int id)
        {
            var value = _abouttService.TGetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateAbout(Team team)
        {
            _abouttService.TUpdate(team);
            return RedirectToAction("AdminIndex");
        }

        // HAKKINDA METİNLERİ
        public IActionResult AboutIndex2()
        {
            var values = _aboutDService.TGetListAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddAbout2()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAbout2(About about)
        {
            _aboutDService.TInsert(about);
            return RedirectToAction("AboutIndex2");
        }

        public IActionResult DeleteAbout2(int id)
        {
            var value = _aboutDService.TGetById(id);
            _aboutDService.TDelete(value);
            return RedirectToAction("AboutIndex2");
        }

        [HttpGet]
        public IActionResult UpdateAbout2(int id)
        {
            var value = _aboutDService.TGetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateAbout2(About about)
        {
            _aboutDService.TUpdate(about);
            return RedirectToAction("AboutIndex2");
        }
    }
}
