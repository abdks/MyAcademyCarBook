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
    public class IReferenceManager : IReferenceService
    {
        private readonly IReferenceDal _referenceDal;

        public IReferenceManager(IReferenceDal referenceDal)
        {
            _referenceDal = referenceDal;
        }

        public void TDelete(Reference entity)
        {
           _referenceDal.Delete(entity);
        }

        public Reference TGetById(int id)
        {
            return _referenceDal.GetById(id);   
        }

        public List<Reference> TGetListAll()
        {
           return _referenceDal.GetAll();
        }

        public void TInsert(Reference entity)
        {
             _referenceDal.Insert (entity);
        }

        public void TUpdate(Reference entity)
        {
            _referenceDal.Update(entity);
        }
    }
}
