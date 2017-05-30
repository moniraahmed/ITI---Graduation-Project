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
   public class ComplaintManager: DataRepositoy<ITIEntities,Student_Complaints>
    {
        public void AddComplaint(Student_Complaints newcomplaint)
        {
            Add(newcomplaint);
        }
    }
}
