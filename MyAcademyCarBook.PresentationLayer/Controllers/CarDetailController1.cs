using Microsoft.AspNetCore.Mvc;
using MyAcademyCarBook.BusinessLayer.Abstract;

namespace MyAcademyCarBook.PresentationLayer.Controllers
{
    public class CarDetailController1 : Controller
    {
        private readonly ICarDetailService _carDetailService;

        public CarDetailController1(ICarDetailService carDetailService)
        {
            _carDetailService = carDetailService;
        }

        public IActionResult Index()
        {
            var values = _carDetailService.TGetListAll();
            return View(values);
        }
    }
}
