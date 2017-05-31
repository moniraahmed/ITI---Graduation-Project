using ITI.Data.DataRepositoy;
using ITI.Data.DBmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Business
{
   public class TrackSupervisorManager : DataRepositoy<ITIEntities, TrackSupervisor>
    {
        //take platformintakeid and return employee id
        public int? GetSupervisor(int id)
        {
            var x = FindobjBy(a => a.PlatformIntakeID==id);
            return x.EmployeeID;
           
        }
        public int? GetPlatformintakeOfSupervisor(int Emp_Id)
        {
            var x = FindobjBy(a => a.EmployeeID == Emp_Id);
            if (x==null)
            {
                return 0;//empty view
            }
            else
            {
                return x.PlatformIntakeID;
            }
        }
    }
}
