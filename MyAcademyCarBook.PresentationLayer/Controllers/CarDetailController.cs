using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyAcademyCarBook.BusinessLayer.Abstract;
using MyAcademyCarBook.EntityLayer.Concrete;

namespace MyAcademyCarBook.PresentationLayer.Controllers
{
    public class CarDetailController : Controller
    {
        private readonly ICarDetailService _carDetailService;
        private readonly ICarService _carService;


        public CarDetailController(ICarDetailService carDetailService, ICarService carService)
        {
            _carDetailService = carDetailService;
            _carService = carService;
        }

        public IActionResult Index()
        {
            var values = _carDetailService.TGetListAll();
            return View(values);
        }
        public IActionResult DeleteCarDetail(int id)
        {
            var value = _carDetailService.TGetById(id);
            _carDetailService.TDelete(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult AddCarDetail()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCarDetail(CarDetails carDetails)
        {
            _carDetailService.TInsert(carDetails);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateCarDetail(int id)
        {
            var value = _carDetailService.TGetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateCarDetail(CarDetails carDetails)
        {
            _carDetailService.TUpdate(carDetails);
            return RedirectToAction("Index");
        }
    }
}
