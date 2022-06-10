using EntityLayer.Concrete;
using EntityLayer.Dextra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IWriterService
    {
        List<Writer> GetList();
        List<Writer> GetList(string p);
        void WriterAdd(Writer writer);
        Writer GetById(int id);
        void WriterDelete(Writer writer);
        void WriterUpdate(Writer writer);
        List<WriterExtra> GetListExtra();
    }
}
