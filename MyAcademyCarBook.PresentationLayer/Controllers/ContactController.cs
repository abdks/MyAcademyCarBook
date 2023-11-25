using Microsoft.AspNetCore.Mvc;
using MyAcademyCarBook.BusinessLayer.Abstract;
using MyAcademyCarBook.EntityLayer.Concrete;

namespace MyAcademyCarBook.PresentationLayer.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService contactService;
        private readonly IContactFormService contactFormService;

        public ContactController(IContactService contactService, IContactFormService contactFormService)
        {
            this.contactService = contactService;
            this.contactFormService = contactFormService;
        }

        public IActionResult Index()
        {
            var values = contactService.TGetListAll();
            return View(values);
        }
        [HttpPost]
        public IActionResult AddContactForm2(ContactForm contactForm)
        {
            contactFormService.TInsert(contactForm);
            return RedirectToAction("Index");
        }
        public IActionResult AdminIndex()
        {
            var values = contactService.TGetListAll();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddContact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddContact(Contact contact)
        {
            contactService.TInsert(contact);
            return RedirectToAction("AdminIndex");
        }
        public IActionResult DeleteContact(int id)
        {
            var value = contactService.TGetById(id);
            contactService.TDelete(value);
            return RedirectToAction("AdminIndex");
        }
        [HttpGet]
        public IActionResult UpdateContact(int id)
        {
            var value = contactService.TGetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateContact(Contact contact)
        {
            contactService.TUpdate(contact);
            return RedirectToAction("AdminIndex");
        }
        //İletişim formu
        public IActionResult AdminIndex2()
        {
            var values = contactFormService.TGetListAll();
            return View(values);
        }
      
        public IActionResult DeleteContact2(int id)
        {
            var value = contactFormService.TGetById(id);
            contactFormService.TDelete(value);
            return RedirectToAction("AdminIndex2");
        }
     

    }
}
