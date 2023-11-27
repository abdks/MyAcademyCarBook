using Microsoft.AspNetCore.Mvc;
using MyAcademyCarBook.BusinessLayer.Abstract;
using MyAcademyCarBook.EntityLayer.Concrete;

namespace MyAcademyCarBook.PresentationLayer.Controllers
{
    public class EndServiceController : Controller
    {
        private readonly IEndServiceService _endServiceService;

        public EndServiceController(IEndServiceService endServiceService)
        {
            _endServiceService = endServiceService;
        }
        public IActionResult Index()
        {
            var values = _endServiceService.TGetListAll();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddService()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddService(EndService endService)
        {
            _endServiceService.TInsert(endService);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteService(int id)
        {
            var value = _endServiceService.TGetById(id);
            _endServiceService.TDelete(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateService(int id)
        {
            var value = _endServiceService.TGetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateService(EndService endService)
        {
            _endServiceService.TUpdate(endService);
            return RedirectToAction("Index");
        }
    }
}
