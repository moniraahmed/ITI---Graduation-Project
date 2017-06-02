using ITI.Data.DataRepositoy;
using ITI.Data.DBmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Business
{
   public class subTrackManager : DataRepositoy<ITIEntities, subTrack>
    {
    public string GetSubTrackName(int? SubTrackID)
        {
            var SubTrack = FindobjBy(a => a.subtrackID == SubTrackID);
            return SubTrack.subtrackName;
        }
    }
}
