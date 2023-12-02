using Microsoft.EntityFrameworkCore;
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
    public class EfCarDetailDal : GenericRepository<CarDetails>, ICarDetailDal
    {
       
        public CarDetails GetCarDetailByCarID(int id)
        {
            using (var context = new CarBookContext())
            {
                var values = context.CarDetails.FirstOrDefault(x => x.CarID == id);
                if (values != null)
                {
                    return values;
                }
                // Eşleşen CarDetail bulunamazsa, null döndürme veya bir istisna fırlatma gibi durumları ele alın.
                return null;
            }
        }

        public CarDetails GetCarDetailWithAuthor(int id)
        {
            var context = new CarBookContext(); 
            var values = context.CarDetails.Include(x=>x.AppUser).Where(y=>y.CarID == id).FirstOrDefault();
            return values;
        }
    }
}
