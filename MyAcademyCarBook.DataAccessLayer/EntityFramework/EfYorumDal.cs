using MyAcademyCarBook.DataAccessLayer.Abstract;
using MyAcademyCarBook.DataAccessLayer.Concrete;
using MyAcademyCarBook.DataAccessLayer.Repositories;
using MyAcademyCarBook.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAcademyCarBook.DataAccessLayer.EntityFramework
{
    public class EfYorumDal : GenericRepository<Yorum>, IYorumDal
    {
        public List<Yorum> GetYorumsByCar(int id)
        {
          var context = new CarBookContext();
          var values = context.Yorums.Where(x => x.CarID == id).ToList();
          return values;
        }
    }
}
