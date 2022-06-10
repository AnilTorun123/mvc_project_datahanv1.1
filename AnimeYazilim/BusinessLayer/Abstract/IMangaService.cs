using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    interface IMangaService
    {
        List<Manga> GetList();
        void MangaAdd(Manga manga);
        Manga GetByID(int id);
        void MangaDelete(Manga manga);
        void MangaUpdate(Manga manga);
    }
}
