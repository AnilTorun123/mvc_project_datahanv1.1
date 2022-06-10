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
    public class MangaManager : IMangaService
    {
        IMangaDal _mangaDal;

        public MangaManager(IMangaDal mangaDal)
        {
            _mangaDal = mangaDal;
        }

        public Manga GetByID(int id)
        {
            return _mangaDal.Get(x => x.MangaID == id);
        }

        public List<Manga> GetList()
        {
            return _mangaDal.List();
        }

        public void MangaAdd(Manga manga)
        {
            _mangaDal.Insert(manga);
        }

        public void MangaDelete(Manga manga)
        {
            _mangaDal.Delete(manga);
        }

        public void MangaUpdate(Manga manga)
        {
            _mangaDal.Update(manga);
        }
    }
}
