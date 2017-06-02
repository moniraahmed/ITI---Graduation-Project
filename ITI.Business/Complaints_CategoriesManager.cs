using AutoMapper;
using ITI.Business.Map;
using ITI.Data.DataRepositoy;
using ITI.Data.DBmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Business
{
   public class Complaints_CategoriesManager : DataRepositoy<ITIEntities, Complain_Category>
    {
        public IEnumerable<Complain_CategoryMap> GetComplaintsCategories()
        {
            var categories = GetAll().ToList();
            return Mapper.Map<IEnumerable<Complain_CategoryMap>>(categories);

        }
    }
}
