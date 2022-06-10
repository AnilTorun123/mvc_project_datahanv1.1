using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMangaEpisodeService
    {
        List<MangaEpisode> GetList();
        List<MangaEpisode> GetListById(int id);
        void MangaEpAdd(MangaEpisode mangaEpisode);
        MangaEpisode GetByID(int id);
        void MangaEpDelete(MangaEpisode mangaEpisode);
        void MangaEpUpdate(MangaEpisode mangaEpisode);
    }
}
