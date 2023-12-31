﻿using MyAcademyCarBook.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAcademyCarBook.BusinessLayer.Abstract
{
    public interface ICarService:IGenericService<Car>
    {
        List<Car> TGetAllCarsWithBrands();

        IEnumerable<Car> FilterCars(int brandId, int categoryId, int capacity, string gearType);

    }
}
