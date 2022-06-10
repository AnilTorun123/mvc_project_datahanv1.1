using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori Adı Boş Bırakılamaz.");
            RuleFor(x => x.CategoryName).MinimumLength(2).WithMessage("Kategori adı için lütfen en az 2 karakter girişi yapınız.");
            RuleFor(x => x.CategoryName).MaximumLength(50).WithMessage("Kategori adı için lütfen 50 karakter girişini geçmeyiniz.");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Açıklama Alanı Boş Bırakılamaz.");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Açıklama Alanı Boş Bırakılamaz.");
            
        }
    }
}
