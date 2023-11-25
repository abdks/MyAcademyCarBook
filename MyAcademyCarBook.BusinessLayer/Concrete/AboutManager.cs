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
    public class AboutManager : IAbouttService
    {
        private readonly IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void TDelete(Team entity)
        {
            _aboutDal.Delete(entity);   
        }

        public Team TGetById(int id)
        {
          return _aboutDal.GetById(id); 
        }

        public List<Team> TGetListAll()
        {
            return _aboutDal.GetAll();
        }

        public void TInsert(Team entity)
        {
            _aboutDal.Insert(entity);
        }

        public void TUpdate(Team entity)
        {
            _aboutDal.Update(entity);
        }
    }
}
