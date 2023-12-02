using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyAcademyCarBook.BusinessLayer.Abstract;

namespace MyAcademyCarBook.PresentationLayer.ViewComponents.CarFilterComponents
{
    public class _CarFilterComponentPartial : ViewComponent
    {
        private readonly IBrandService _brandService;
        private readonly ICarCategoryService _carCategoryService;
        private readonly ICarService _carService;

        public _CarFilterComponentPartial(ICarService carService, IBrandService brandService, ICarCategoryService carCategoryService)
        {
            _carService = carService;
            _brandService = brandService;
            _carCategoryService = carCategoryService;
        }
      

        public IViewComponentResult Invoke()
        {

            try
            {
                List<SelectListItem> values = _brandService.TGetListAll()
            .Where(x => x.BrandName != null)
            .Select(x => new SelectListItem
            {
                Text = x.BrandName,
                Value = x.BrandID.ToString()
            })
            .ToList();
                //kategori
                List<SelectListItem> value = _carCategoryService.TGetListAll()
            .Where(x => x.CategoryName != null)
            .Select(x => new SelectListItem
            {
                Text = x.CategoryName,
                Value = x.CarCategoryID.ToString()
            })
            .ToList();
                

                ViewBag.v = values;
                ViewBag.d = value;


                return View();
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }
    }
}
