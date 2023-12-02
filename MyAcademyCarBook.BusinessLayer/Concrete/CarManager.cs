using Microsoft.EntityFrameworkCore;
using MyAcademyCarBook.BusinessLayer.Abstract;
using MyAcademyCarBook.DataAccessLayer.Abstract;
using MyAcademyCarBook.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAcademyCarBook.BusinessLayer.Concrete
{
    public class CarManager : ICarService
    {
        private readonly ICarDal _carDal;
        private readonly IBrandDal _brandDal;
        private readonly ICarCategoryDal _categoryDal;
        private readonly ICarStatusDal _statusDal;

        public CarManager(ICarDal carDal, IBrandDal brandDal, ICarCategoryDal categoryDal, ICarStatusDal statusDal)
        {
            _carDal = carDal;
            _brandDal = brandDal;
            _categoryDal = categoryDal;
            _statusDal = statusDal;
        }

        public IEnumerable<Car> FilterCars(int brandId, int categoryId, int personcount, string gearType)
        {
            var cars = _carDal.GetAllCarsWithBrands().ToList(); // ToList() ekledik

            if (brandId != 0)
            {
                cars = cars.Where(c => c.BrandID == brandId).ToList(); // ToList() ekledik
            }

            if (categoryId != 0)
            {
                cars = cars.Where(c => c.CarCategoryID == categoryId).ToList(); // ToList() ekledik
            }

            if (personcount != 0)
            {
                cars = cars.Where(c => c.PersonCount == personcount).ToList(); // ToList() ekledik
            }

            if (!string.IsNullOrEmpty(gearType))
            {
                cars = cars.Where(c => c.GearType == gearType).ToList(); // ToList() ekledik
            }

            return cars;
        }

        public void TDelete(Car entity)
        {
            _carDal.Delete(entity);
        }

        public List<Car> TGetAllCarsWithBrands()
        {
            var cars = _carDal.GetAllCarsWithBrands();

            foreach (var car in cars)
            {
                var category = _carDal.GetCarCategoryById(car.CarCategoryID);
                car.CarCategory = category; // Car sınıfında CarCategory property'si olmalı
            }

            return cars;



           // return _carDal.GetAllCarsWithBrands();
        }

        public Car TGetById(int id)
        {
            if(id != null)
                    {
                return _carDal.GetById(id);
            }
            return _carDal.GetById(0);//araba bulunamadı
        }

        public List<Car> TGetListAll()
        {
           //Bu işlemi yapmaya yetkiliyse
           return _carDal.GetAll();
        }

        public void TInsert(Car entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException(nameof(entity), "Car entity cannot be null.");
                }

                if (entity.Year < 2000)
                {
                    throw new ArgumentException("Car year must be 2010 or later.", nameof(entity.Year));
                }

                // Diğer hata kontrolleri buraya eklenebilir

                _carDal.Insert(entity);
            }
            catch (Exception ex)
            {
                // Hata durumunda loglama veya diğer işlemler burada yapılabilir
                // Loglama örneği: _logger.LogError(ex, "TInsert metodu hatası");
                throw; // Hata fırlatıldıktan sonra üst katmana aktar
            }

        }



        public void TUpdate(Car entity)
        {
           _carDal.Update(entity);
        }
    }
}
