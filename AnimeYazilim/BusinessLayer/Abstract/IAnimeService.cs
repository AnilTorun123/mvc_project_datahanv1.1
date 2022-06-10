using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAnimeService
    {
        List<Anime> GetList();
        List<Anime> GetList(int id);
        void AnimeAdd(Anime anime);
        Anime GetByID(int id);
        void AnimeDelete(Anime anime);
        void AnimeUpdate(Anime anime);
    }
}
