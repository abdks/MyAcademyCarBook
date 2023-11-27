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
    public class IEndServiceManager : IEndServiceService
    {
        private readonly IEndServiceDal _endServiceDal;

        public IEndServiceManager(IEndServiceDal endServiceDal)
        {
            _endServiceDal = endServiceDal;
        }

        public void TDelete(EndService entity)
        {
           _endServiceDal.Delete(entity);
        }

        public EndService TGetById(int id)
        {
            return _endServiceDal.GetById(id);
        }

        public List<EndService> TGetListAll()
        {
          return _endServiceDal.GetAll();
        }

        public void TInsert(EndService entity)
        {
            _endServiceDal.Insert(entity);
        }

        public void TUpdate(EndService entity)
        {
           _endServiceDal.Update(entity);
        }
    }
}
