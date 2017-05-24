using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITI.Business.Map;
using ITI.Data.DataRepositoy;
using ITI.Data.DBmodel;
using AutoMapper;

namespace ITI.Business.Manager
{
    public class programManager : DataRepositoy<ITIEntities, program>
    {
        public IEnumerable<programMap> getprogrm()
        {
            var x = GetAll().ToList();
            return   Mapper.Map<IEnumerable<programMap>>(x);
          //  
          //var xx=  Mapper.Map <programMap> x();
          //  return  ;
        }
        public programMap getprogrm(int id)
        {
            var x = Get(id);
            return Mapper.Map<programMap>(x);
            //  
            //var xx=  Mapper.Map <programMap> x();
            //  return  ;
        }
    }
}
