﻿using MyAcademyCarBook.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAcademyCarBook.DataAccessLayer.Abstract
{
    public interface ICarDetailDal:IGenericDal<CarDetails>
    {
        
        CarDetails GetCarDetailByCarID(int id);
        CarDetails GetCarDetailWithAuthor(int id);
    }
}
