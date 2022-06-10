using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAnimeEpisodeService
    {
        List<AnimeEpisode> GetList();
        List<AnimeEpisode> GetListById(int id);
        void AnimeEpAdd(AnimeEpisode animeEpisode);
        AnimeEpisode GetByID(int id);
        void AnimeEpDelete(AnimeEpisode animeEpisode);
        void AnimeEpUpdate(AnimeEpisode animeEpisode);
    }
}
