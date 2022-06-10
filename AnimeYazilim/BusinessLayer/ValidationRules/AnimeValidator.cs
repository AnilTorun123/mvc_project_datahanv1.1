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
    public class AnimeValidator : AbstractValidator<Anime>
    {
        //su bölüm sayısısı için kuralı halletmeliyim bi ara (sadece sayı girilmelidir seklinde)


        //private bool IsAboutValid(string arg)
        //{
        //    try
        //    {
        //        Regex regex = new Regex(@"^(?=.*[!0-9]*)");
        //        return regex.IsMatch(arg);
        //    }
        //    catch (Exception)
        //    {

        //        return false;
        //    }
        //}
        public AnimeValidator()
        {


            RuleFor(x => x.AnimeName).NotEmpty().WithMessage("Anime adı boş bırakılamaz.");
            RuleFor(x => x.AnimeDemographic).NotEmpty().WithMessage("Anime türü boş bırakılamaz.");
            RuleFor(x => x.AnimeEpisode).NotEmpty().WithMessage("Anime bölüm sayısı boş bırakılamaz.");
            //RuleFor(x => x.AnimeEpisode).Must(IsAboutValid).WithMessage("Bölüm sayısı için sadece sayı girilmelidir.");
            RuleFor(x => x.AnimeProducers).NotEmpty().WithMessage("Anime yayıncı alanı boş bırakılamaz.");
            RuleFor(x => x.AnimeProducers).NotEmpty().WithMessage("Anime yayıncı alanı boş bırakılamaz.");


        }
    }
}
