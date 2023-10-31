using Microsoft.AspNetCore.Mvc;

namespace MyAcademyCarBook.PresentationLayer.ViewComponents.UILayout
{
    public class _HeadUILayoutPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
