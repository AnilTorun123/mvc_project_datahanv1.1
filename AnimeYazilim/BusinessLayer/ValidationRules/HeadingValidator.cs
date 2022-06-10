using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class HeadingValidator : AbstractValidator<Heading>
    {
        public HeadingValidator()
        {
            RuleFor(x => x.HeadingName).NotEmpty().WithMessage("Başlık Adı Boş Bırakılamaz.");
            RuleFor(x => x.HeadingName).MinimumLength(2).WithMessage("Başlık adı için lütfen en az 2 karakter girişi yapınız.");
            RuleFor(x => x.HeadingName).MaximumLength(50).WithMessage("Başlık adı için lütfen 50 karakter girişini geçmeyiniz.");
           

        }
    }
}
