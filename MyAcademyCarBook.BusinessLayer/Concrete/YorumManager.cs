using Microsoft.EntityFrameworkCore.Storage;
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
    public class YorumManager : IYorumService
    {
        private readonly IYorumDal _yorumDal;

        public YorumManager(IYorumDal yorumDal)
        {
            _yorumDal = yorumDal;
        }

        public void TDelete(Yorum entity)
        {
            _yorumDal.Delete(entity);
        }

        public Yorum TGetById(int id)
        {
           return _yorumDal.GetById(id);
        }

        public List<Yorum> TGetListAll()
        {
          return _yorumDal.GetAll();
        }

        public List<Yorum> TGetYorumsByCar(int id)
        {
            return _yorumDal.GetYorumsByCar(id);
        }

        public void TInsert(Yorum entity)
        {
            _yorumDal.Insert(entity);
        }

        public void TUpdate(Yorum entity)
        {
           _yorumDal.Update(entity);
        }
    }
}
