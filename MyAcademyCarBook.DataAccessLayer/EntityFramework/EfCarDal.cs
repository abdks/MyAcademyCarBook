using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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
    public class EfCarDal : GenericRepository<Car>,ICarDal
    {
        public List<Car>GetAllCarsWithBrands()
        {
            var context = new CarBookContext();
            var values = context.Cars.Include(x => x.Brand).Include(y => y.CarStatus).ToList();
            return values;
        }

        public CarCategory GetCarCategoryById(int carcategory)
        {
            using (var context = new CarBookContext())
            {
                return context.CarCategories.FirstOrDefault(c => c.CarCategoryID == carcategory);
            }
        }
    }
}
