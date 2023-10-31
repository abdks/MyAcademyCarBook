using Microsoft.AspNetCore.Mvc;

namespace MyAcademyCarBook.PresentationLayer.Controllers
{
	public class ServiceController1 : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
