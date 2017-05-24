
using AutoMapper;
using ITI.Business.Map;
using ITI.Data;
using ITI.Data.DataRepositoy;
using ITI.Data.DBmodel;
using System.Collections.Generic;
using System.Linq;


namespace ITI.Business.Manager
{
    public class IntakManager : DataRepositoy<ITIEntities, Intake>
    {
        public IntakeMap getIntak(int id)
        {
            var x = Get(id);
            return Mapper.Map<IntakeMap>(x);
           
        }
    }
}