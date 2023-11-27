using Microsoft.AspNetCore.Mvc;
using MyAcademyCarBook.BusinessLayer.Abstract;
using MyAcademyCarBook.EntityLayer.Concrete;

namespace MyAcademyCarBook.PresentationLayer.Controllers
{
    public class IndexPageController : Controller
    {
        private readonly IReferenceService _referenceService;
        private readonly IEndServiceService _endServiceService;
        private readonly ICarService _carService;
        public IndexPageController(IReferenceService referenceService, IEndServiceService endServiceService, ICarService carService)
        {
            _referenceService = referenceService;
            _endServiceService = endServiceService;
            _carService = carService;
        }

        public class CombinedDataViewModel
        {
            public IEnumerable<Reference> ReferenceValues { get; set; }
            public IEnumerable<EndService> EndServiceValues { get; set; }
            public IEnumerable<Car> CarValues { get; set; }
        }





        public IActionResult Index()
        {
            var referenceValues = _referenceService.TGetListAll();
            var serviceValues = _endServiceService.TGetListAll();
            var carValues = _carService.TGetListAll();
            var combinedData = new CombinedDataViewModel
            {
                CarValues = carValues,
                ReferenceValues = referenceValues,
                EndServiceValues = serviceValues
            };
            return View(combinedData);

        }
       
    }
}
