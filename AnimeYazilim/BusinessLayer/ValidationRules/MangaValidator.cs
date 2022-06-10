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
    public class MangaValidator : AbstractValidator<Manga>
    {
        public MangaValidator()
        {
            RuleFor(x => x.MangaName).NotEmpty().WithMessage("Manga adı boş bırakılamaz.");
            RuleFor(x => x.MangaDemographic).NotEmpty().WithMessage("Manga türü boş bırakılamaz.");
        }
    }

}
