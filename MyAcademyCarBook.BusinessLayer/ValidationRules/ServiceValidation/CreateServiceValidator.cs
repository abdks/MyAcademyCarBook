using FluentValidation;
using MyAcademyCarBook.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAcademyCarBook.BusinessLayer.ValidationRules.ServiceValidation
{
    public class CreateServiceValidator:AbstractValidator<Service>
    {
        public CreateServiceValidator()
        {
                    RuleFor(x=>x.Title).NotEmpty().WithMessage("Başlığı Boş Geçemezsiniz");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklamayı Boş Geçemezsiniz");
            RuleFor(x => x.Icon).NotEmpty().WithMessage("İcon Alanını Boş Geçemezsiniz");
            RuleFor(x => x.Title).MinimumLength(3).WithMessage("Lütfen En Az 3 Karakter Veri Girişi Yapınız");
            RuleFor(x => x.Title).MaximumLength(30).WithMessage("Lütfen En fazla 30 Karakter Veri Girişi Yapınız");
        }
    }
}
