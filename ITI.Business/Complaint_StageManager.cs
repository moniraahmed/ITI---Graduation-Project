using ITI.Data.DataRepositoy;
using ITI.Data.DBmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Business
{
   public class Complaint_StageManager : DataRepositoy<ITIEntities, Complaint_Stage>
    {
       public void AddNewStage(Complaint_Stage newstage)
        {
            Add(newstage);
        }
        
    }
}
