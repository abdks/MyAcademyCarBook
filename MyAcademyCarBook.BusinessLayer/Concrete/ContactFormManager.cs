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
    public class ContactFormManager : IContactFormService
    {
        private readonly IContactFormDal _contactFormDal;

        public ContactFormManager(IContactFormDal contactFormDal)
        {
            _contactFormDal = contactFormDal;
        }

        public void TDelete(ContactForm entity)
        {
           _contactFormDal.Delete(entity);
        }

        public ContactForm TGetById(int id)
        {
            return _contactFormDal.GetById(id);
        }

        public List<ContactForm> TGetListAll()
        {
           return _contactFormDal.GetAll();
        }

        public void TInsert(ContactForm entity)
        {
            _contactFormDal.Insert(entity);
        }

        public void TUpdate(ContactForm entity)
        {
           _contactFormDal.Update(entity);
        }
    }
}
