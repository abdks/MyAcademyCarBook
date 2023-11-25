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
    public class AboutWManager : IAboutDService
    {
        private readonly IAboutWDal _aboutWDal;

        public AboutWManager(IAboutWDal aboutWDal)
        {
            _aboutWDal = aboutWDal;
        }

        public void TDelete(About entity)
        {
           _aboutWDal.Delete(entity);
        }

        public About TGetById(int id)
        {
            return _aboutWDal.GetById(id);
        }

        public List<About> TGetListAll()
        {
            return _aboutWDal.GetAll();
        }

        public void TInsert(About entity)
        {
           _aboutWDal.Insert(entity);
        }

        public void TUpdate(About entity)
        {
           _aboutWDal.Update(entity);
        }
    }
}
