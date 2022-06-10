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
    public class AnimeEpisodeManager : IAnimeEpisodeService
    {
        IAnimeEpisodeDal _animeEpisodeDal;
        public AnimeEpisodeManager(IAnimeEpisodeDal animeEpisodeDal)
        {
            _animeEpisodeDal = animeEpisodeDal;
        }

        public void AnimeEpAdd(AnimeEpisode animeEpisode)
        {
            _animeEpisodeDal.Insert(animeEpisode);
        }

        public void AnimeEpDelete(AnimeEpisode animeEpisode)
        {
            _animeEpisodeDal.Delete(animeEpisode);
        }

        public void AnimeEpUpdate(AnimeEpisode animeEpisode)
        {
            _animeEpisodeDal.Update(animeEpisode);
        }

        public AnimeEpisode GetByID(int id)
        {
            return _animeEpisodeDal.Get(x => x.AnimeEpisodeID == id);
        }

        public List<AnimeEpisode> GetList()
        {
            return _animeEpisodeDal.List();
        }

        public List<AnimeEpisode> GetListById(int id)
        {
            return _animeEpisodeDal.List(x => x.Anime.AnimeID == id);
            //surada bir orderby yapmalıyımda nasıl yapıldıgını cozemedim simdilik. (gelen bölümleri animenum a göre sıralamalı azdan coga aynı seyi animewatch icinde yapmalıyım
        }
    }
}
