using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AdminValidator : AbstractValidator<Admin>
    {
        public AdminValidator()
        {
            RuleFor(x => x.AdminUserName).NotEmpty().WithMessage("Admin adı boş bırakılamaz.");
            RuleFor(x => x.AdminUserName).MinimumLength(2).WithMessage("Admin adı için lütfen en az 2 karakter girişi yapınız.");
            RuleFor(x => x.AdminUserName).MaximumLength(50).WithMessage("Admin adı için lütfen 50 karakter girişini geçmeyiniz.");

            RuleFor(x => x.AdminPassword).NotEmpty().WithMessage("Şifre boş bırakılamaz.");
            RuleFor(x => x.AdminPassword).MinimumLength(2).WithMessage("Şifre için lütfen en az 2 karakter girişi yapınız.");
            RuleFor(x => x.AdminPassword).MaximumLength(50).WithMessage("Şifre için lütfen 50 karakter girişini geçmeyiniz.");
        }
    }
}
