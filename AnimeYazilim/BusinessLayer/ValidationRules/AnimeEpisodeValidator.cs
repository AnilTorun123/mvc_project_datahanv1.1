using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AnimeEpisodeValidator : AbstractValidator<AnimeEpisode>
    {
        public AnimeEpisodeValidator()
        {
            RuleFor(x => x.AnimeEpNum).NotEmpty().WithMessage("Anime bölüm sayısı boş bırakılamaz.");
            RuleFor(x => x.AnimeEp).NotEmpty().WithMessage("Anime bölümü boş bırakılamaz.");
        }
    }
}
