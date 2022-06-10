using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı adresi boş bırakılamaz.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu alanı boş bırakılamaz.");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesaj alanı boş bırakılamaz.");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesaj alanı boş bırakılamaz.");

            RuleFor(x => x.Subject).MinimumLength(2).WithMessage("lütfen en az 2 karakter girişi yapınız.");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("lütfen 100 karakter girişini geçmeyiniz.");

            //ödev mail kontrolü: mail geçerlimi kontrolü yapılacak
        }
       
    }
}
