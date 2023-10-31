using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyAcademyCarBook.EntityLayer.Concrete;
using MyAcademyCarBook.PresentationLayer.Models;

namespace MyAcademyCarBook.PresentationLayer.Controllers
{
    public class LoginController : Controller
    {
        public readonly SignInManager<AppUser> _sıgnInManager;
        public LoginController(SignInManager<AppUser> sıgnInManager)
        {
            _sıgnInManager = sıgnInManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel model)
        {
            var result = await _sıgnInManager.PasswordSignInAsync(model.Username,model.Password,false,false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index","CarStatus");
            }
            return View();
        }
    }
}
