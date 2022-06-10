using EntityLayer.Concrete;
using EntityLayer.Dextra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ICategoryDal: IRepository<Category>
    {        
        List<CategoryExtra> GetCategoryListExtra();
    }
}
