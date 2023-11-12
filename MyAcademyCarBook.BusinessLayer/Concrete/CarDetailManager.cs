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
    public class CarDetailManager : ICarDetailService
    {
        private readonly ICarDetailDal _carDetailDal;

        public CarDetailManager(ICarDetailDal carDetailDal)
        {
            _carDetailDal = carDetailDal;
        }

        public void TDelete(CarDetails entity)
        {
            _carDetailDal.Delete(entity);
        }

        public CarDetails TGetById(int id)
        {
            return _carDetailDal.GetById(id);
        }

        public CarDetails TGetCarDetailByCarID(int id)
        {
            return _carDetailDal.GetCarDetailByCarID(id);
        }

        public CarDetails TGetCarDetailWithAuthor(int id)
        {
            return _carDetailDal.GetCarDetailWithAuthor(id);
        }

        public List<CarDetails> TGetListAll()
        {
            return _carDetailDal.GetAll();
        }

        public void TInsert(CarDetails entity)
        {
            _carDetailDal.Insert(entity);
        }

        public void TUpdate(CarDetails entity)
        {
            _carDetailDal.Update(entity);
        }
    }
}
