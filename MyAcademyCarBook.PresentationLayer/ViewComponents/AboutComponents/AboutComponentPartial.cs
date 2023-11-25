using Microsoft.AspNetCore.Mvc;

namespace MyAcademyCarBook.PresentationLayer.ViewComponents.AboutComponents
{
    public class AboutComponentPartial : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
