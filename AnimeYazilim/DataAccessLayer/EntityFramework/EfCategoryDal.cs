using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using EntityLayer.Dextra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        public List<CategoryExtra> GetCategoryListExtra()
        {
            using (var context = new Context())
            {
                var result = from x in context.Categories
                             select new CategoryExtra
                             {
                                 CategoryName = x.CategoryName,
                                 CategoryCount = context.Headings.Where(h => h.CategoryID == x.CategoryID).Count()
                             };
                return result.ToList();
            }
        }
    }
}
