﻿using MyAcademyCarBook.BusinessLayer.Abstract;
using MyAcademyCarBook.DataAccessLayer.Abstract;
using MyAcademyCarBook.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAcademyCarBook.BusinessLayer.Concrete
{
    public class IHowItWorkStepManager : IHowItWorksStepService
    {
        private readonly IHowItWorkStepDal _howItWorkStepDal;

        public IHowItWorkStepManager(IHowItWorkStepDal howItWorkStepDal)
        {
            _howItWorkStepDal = howItWorkStepDal;
        }

        public void TDelete(HowItWorkStep entity)
        {
           _howItWorkStepDal.Delete(entity);
        }

        public HowItWorkStep TGetById(int id)
        {
            return _howItWorkStepDal.GetById(id);
        }

        public List<HowItWorkStep> TGetListAll()
        {
            return _howItWorkStepDal.GetAll();
        }

        public void TInsert(HowItWorkStep entity)
        {
           _howItWorkStepDal.Insert(entity);
        }

        public void TUpdate(HowItWorkStep entity)
        {
            _howItWorkStepDal.Update(entity);
        }
    }
}
