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
    public class AnimeManager : IAnimeService
    {
        IAnimeDal _animeDal;
        IContentDal _contentDal;
        public AnimeManager(IAnimeDal animeDal)
        {
            _animeDal = animeDal;
        }

        public void AnimeAdd(Anime anime)
        {
            _animeDal.Insert(anime);
        }

        public void AnimeDelete(Anime anime)
        {
            _animeDal.Delete(anime);
        }

        public void AnimeUpdate(Anime anime)
        {
            _animeDal.Update(anime);
        }

        public Anime GetByID(int id)
        {
            return _animeDal.Get(x => x.AnimeID == id);
        }

        public List<Anime> GetList()
        {
            return _animeDal.List();
        }

        public List<Anime> GetList(int id)
        {
            return _animeDal.List(x => x.WriterID == id);
        }

        //public List<Content> GetListByWriter(int id)
        //{
        //    return _contentDal.List(x => x.WriterID == id);
        //}
    }
}
