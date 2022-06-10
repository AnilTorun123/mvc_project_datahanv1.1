using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator :AbstractValidator<Writer>    
    {
        //murat hocanın istediği ödev alternatif 2:

        //private bool IsAboutValid(string arg)
        //{
        //    try
        //    {
        //        Regex regex = new Regex(@"^(?=.*[a,A])");
        //        return regex.IsMatch(arg);
        //    }
        //    catch (Exception)
        //    {

        //        return false;
        //    }
        //}
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adı boş bırakılamaz.");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar soyadı boş bırakılamaz.");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkımda kısmı boş bırakılamaz.");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Ünvan kısmı boş bırakılamaz.");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Yazar adı için lütfen en az 2 karakter girişi yapınız.");
            RuleFor(x => x.WriterSurname).MinimumLength(2).WithMessage("Yazar soyadı için lütfen en az 2 karakter girişi yapınız.");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Yazar adı için lütfen 50 karakter girişini geçmeyiniz.");
            RuleFor(x => x.WriterSurname).MaximumLength(50).WithMessage("Yazar soyadı için lütfen 50 karakter girişini geçmeyiniz.");

            //murat hocanın istediği ödev alternatif 1:
            //RuleFor(x => x.WriterAbout).Must(x => x != null && x.ToUpper().Contains("A")).WithMessage("Hakkında kısmı en az bir tane a harfi içermelidir");

            //murat hocanın istediği ödev alternatif 2:
            //RuleFor(x => x.WriterAbout).Must(IsAboutValid).WithMessage("Hakkında kısmında en az bir defa a harfi kullanılmalıdır");


        }

    }
}
