using MyAcademyCarBook.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAcademyCarBook.BusinessLayer.Abstract
{
    public  interface ICarDetailService:IGenericService<CarDetails>
    {
        CarDetails TGetCarDetailWithAuthor(int id);

        CarDetails TGetCarDetailByCarID(int id);

    }
}
