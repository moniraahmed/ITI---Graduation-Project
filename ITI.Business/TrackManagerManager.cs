using ITI.Data.DataRepositoy;
using ITI.Data.DBmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Business
{
    public class TrackManagerManager : DataRepositoy<ITIEntities, TrackManager>
    {
        public IEnumerable<TrackManager> GetPlatformintakeOfManager(int Emp_Id)
        {
            var x = FindBy(a => a.EmployeeID == Emp_Id).ToList();
            if (x == null)
            {
                return null;//empty view
            }
            else
            {
                return x;
            }
        }

    }
}
