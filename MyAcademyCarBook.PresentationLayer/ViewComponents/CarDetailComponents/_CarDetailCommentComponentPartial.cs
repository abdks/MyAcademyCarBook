using Microsoft.AspNetCore.Mvc;
using MyAcademyCarBook.BusinessLayer.Abstract;

namespace MyAcademyCarBook.PresentationLayer.ViewComponents.CarDetailComponents
{
    public class _CarDetailCommentComponentPartial : ViewComponent
    {
        private readonly IYorumService _yorumService;

        public _CarDetailCommentComponentPartial(IYorumService yorumService)
        {
            _yorumService = yorumService;
        }

        public IViewComponentResult Invoke(int id)
        {
            var values = _yorumService.TGetYorumsByCar(id);
            return View(values); 
        }


    }
}
