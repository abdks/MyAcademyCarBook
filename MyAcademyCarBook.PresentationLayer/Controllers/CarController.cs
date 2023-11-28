using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyAcademyCarBook.BusinessLayer.Abstract;
using MyAcademyCarBook.EntityLayer.Concrete;
using X.PagedList;
namespace MyAcademyCarBook.PresentationLayer.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService _carService;
        private readonly ICarDetailService _carDetailService;
        private readonly IBrandService _brandService;
        private readonly ICarCategoryService _carCategoryService;
        private readonly ICarStatusService _carStatusService;
        public CarController(ICarService carService, ICarDetailService carDetailService, IBrandService brandService, ICarCategoryService carCategoryService, ICarStatusService carStatusService)
        {
            _carService = carService;
            _carDetailService = carDetailService;
            _brandService = brandService;
            _carCategoryService = carCategoryService;
            _carStatusService = carStatusService;
        }
        //deneme deneme deneme deneme
        public IActionResult Index()
        {
            var values = _carService.TGetListAll();
            return View(values);
        }
        public IActionResult Index2()
        {
            var values = _carService.TGetAllCarsWithBrands();
            return View(values);
        }
        public IActionResult CarList(int page = 1) 
        {

            ViewBag.title1 = "Araba Listesi";
            ViewBag.title2 = "Sizin İçin Araç Listemiz";
            //var values = _carService.TGetAllCarsWithBrands();
            //return View(values).ToPagedList(a,3);
            var result = _carService.TGetAllCarsWithBrands();

            var values = result.ToPagedList(page, 6);
            return View(values);

        }
        public IActionResult CarDetail(int id)
        {
            ViewBag.title1 = "Araba Detayları";
            ViewBag.title2 = "Son Araç Detayları";
            ViewBag.i = id;
            var value = _carDetailService.TGetCarDetailByCarID(id);
            ViewBag.v = value.Description;
            return View();
        }


        public IActionResult DeleteCar(int id)
        {
            var value = _carService.TGetById(id);
            _carService.TDelete(value);
            return RedirectToAction("Index2");
        }
        [HttpGet]
        public IActionResult CreateCar()
        {
       
            try
            { List<SelectListItem> values = _brandService.TGetListAll()
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
                //Araba Statüsü
                List<SelectListItem> val = _carStatusService.TGetListAll()
           .Where(x => x.CarStatusName != null) 
           .Select(x => new SelectListItem
           {
               Text = x.CarStatusName,
               Value = x.CarStatusID.ToString()
           })
           .ToList();

                ViewBag.v = values;
                ViewBag.d = value;
                ViewBag.e = val;


        return View();
            }
            catch (Exception ex)
            {
                return View("Error"); 
            }
        }
        [HttpPost]
        public IActionResult CreateCar(Car car)
        {
            _carService.TInsert(car);
            return RedirectToAction("Index2");
        }


        [HttpGet]
        public IActionResult UpdateCar(int id)
        {

            var value = _carService.TGetById(id);

            // CarCategoryID, BrandID ve CarStatusID için SelectListItems oluşturun
            List<SelectListItem> categories = _carCategoryService.TGetListAll()
                .Where(x => x.CategoryName != null)
                .Select(x => new SelectListItem
                {
                    Text = x.CategoryName,
                    Value = x.CarCategoryID.ToString()
                })
                .ToList();

            List<SelectListItem> brands = _brandService.TGetListAll()
                .Where(x => x.BrandName != null)
                .Select(x => new SelectListItem
                {
                    Text = x.BrandName,
                    Value = x.BrandID.ToString()
                })
                .ToList();

            List<SelectListItem> statuses = _carStatusService.TGetListAll()
                .Where(x => x.CarStatusName != null)
                .Select(x => new SelectListItem
                {
                    Text = x.CarStatusName,
                    Value = x.CarStatusID.ToString()
                })
                .ToList();

            // ViewBag'e bu listeleri ekleyin
            ViewBag.CarCategoryList = categories;
            ViewBag.BrandList = brands;
            ViewBag.CarStatusList = statuses;

            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateCar(Car car)
        {
            _carService.TUpdate(car);
            return RedirectToAction("Index2");
        }





    }
}
