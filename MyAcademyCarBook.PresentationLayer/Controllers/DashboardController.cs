using Microsoft.AspNetCore.Mvc;
using MyAcademyCarBook.DataAccessLayer.Abstract;
using MyAcademyCarBook.EntityLayer.Concrete;
using System.Collections.Generic;



namespace MyAcademyCarBook.PresentationLayer.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ICarDal _carDal;
        private readonly ICarCategoryDal _categoryDal;
        private readonly IBrandDal _brandDal;
        private readonly IContactDal _contactDal;
        private readonly IContactFormDal _contactFormDal;
        

        public DashboardController(ICarDal carDal, ICarCategoryDal categoryDal, IBrandDal brandDal, IContactDal contactDal, IContactFormDal contactFormDal)
        {
            _carDal = carDal;
            _categoryDal = categoryDal;
            _brandDal = brandDal;
            _contactDal = contactDal;
            _contactFormDal = contactFormDal;
        }

        public class DashboardViewModel
        {
            public List<Car> Cars { get; set; }
            public List<Contact> Contacts { get; set; }
            public List<ContactForm> contactForms { get; set; }
            public List<CarCategory> carCategories { get; set; }
            public List<Brand> brands { get; set; }
        }

        public IActionResult Index()
        {



       
        // View'e araç sayısını gönder
        int carCount = _carDal.GetAll().Count;
            int categoryCount = _categoryDal.GetAll().Count();
            int brandCount = _brandDal.GetAll().Count();
            int contactCount = _contactDal.GetAll().Count();
            
            // View'e araç sayısını gönder
            ViewBag.CarCount = carCount;
            ViewBag.CategoryCount = categoryCount;
            ViewBag.BrandCount = brandCount;
            ViewBag.ContactCount = contactCount;

            //Verileri Çek
            var cars = _carDal.GetAll();
            var contacts = _contactDal.GetAll();
            var contactform = _contactFormDal.GetAll();
            var carcategory = _categoryDal.GetAll();
            var brand = _brandDal.GetAll();
            var viewModel = new DashboardViewModel
            {
                Cars = cars,
                Contacts = contacts,
                contactForms = contactform,
                carCategories = carcategory,
                brands = brand
            };


            return View(viewModel);
        }
    }
}
