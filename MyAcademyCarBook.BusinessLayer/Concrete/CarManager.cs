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

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void TDelete(Car entity)
        {
            _carDal.Delete(entity);
        }

        public List<Car> TGetAllCarsWithBrands()
        {
            return _carDal.GetAllCarsWithBrands();
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
