using Microsoft.AspNetCore.Mvc;
using MyAcademyCarBook.BusinessLayer.Abstract;
using MyAcademyCarBook.EntityLayer.Concrete;

namespace MyAcademyCarBook.PresentationLayer.Controllers
{
    public class ReferenceController : Controller
    {
        private readonly IReferenceService _referenceService;

        public ReferenceController(IReferenceService referenceService)
        {
            _referenceService = referenceService;
        }

        public IActionResult Index()
        {
            var values = _referenceService.TGetListAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateReference()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateReference(Reference reference)
        {
            _referenceService.TInsert(reference);
            return RedirectToAction("Index");
        }
        public IActionResult RemoveReference(int id)
        {
            var value = _referenceService.TGetById(id);
            _referenceService.TDelete(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateReference(int id)
        {
            var value = _referenceService.TGetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateReference(Reference reference)
        {
            _referenceService.TUpdate(reference);
            return RedirectToAction("Index");
        }



    }
}
