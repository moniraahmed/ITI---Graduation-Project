using ITI.Data.DataRepositoy;
using ITI.Data.DBmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Business
{
    public class StageManager : DataRepositoy<ITIEntities,Stage>
    {
        public int GetDuration(int StageID, int Cat_ID)
        {
            var st = FindobjBy(a => a.ID == StageID && a.FK_CategoryID== Cat_ID);
            return st.Duration;
        }
    }
}
