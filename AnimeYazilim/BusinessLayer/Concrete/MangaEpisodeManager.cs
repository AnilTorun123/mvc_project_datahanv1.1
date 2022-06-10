using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MangaEpisodeManager : IMangaEpisodeService
    {
        IMangaEpisodeDal _mangaEpisodeDal;

        public MangaEpisodeManager(IMangaEpisodeDal mangaEpisodeDal)
        {
            _mangaEpisodeDal = mangaEpisodeDal;
        }

        public MangaEpisode GetByID(int id)
        {
            return _mangaEpisodeDal.Get(x => x.MangaEpisodeID == id);
        }

        public List<MangaEpisode> GetList()
        {
            return _mangaEpisodeDal.List();
        }

        public List<MangaEpisode> GetListById(int id)
        {
            return _mangaEpisodeDal.List(x => x.Manga.MangaID == id);
        }

        public void MangaEpAdd(MangaEpisode mangaEpisode)
        {
            _mangaEpisodeDal.Insert(mangaEpisode);
        }

        public void MangaEpDelete(MangaEpisode mangaEpisode)
        {
            _mangaEpisodeDal.Delete(mangaEpisode);
        }

        public void MangaEpUpdate(MangaEpisode mangaEpisode)
        {
            _mangaEpisodeDal.Update(mangaEpisode);
        }
    }
}
