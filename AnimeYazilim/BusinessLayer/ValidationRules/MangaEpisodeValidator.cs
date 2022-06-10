using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MangaEpisodeValidator : AbstractValidator<MangaEpisode>
    {
        public MangaEpisodeValidator()
        {
            RuleFor(x => x.MangaEpNum).NotEmpty().WithMessage("Manga bölüm sayısı boş bırakılamaz.");
            RuleFor(x => x.MangaEpPage1).NotEmpty().WithMessage("Manga en azından tek sayfa eklenmesi gerek birinci sayfa boş bırakılamaz");
        }
    }
}
