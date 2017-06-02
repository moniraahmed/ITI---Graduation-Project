using ITI.Data.DataRepositoy;
using ITI.Data.DBmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Business
{
  public class PlatfromIntakeManager:DataRepositoy<ITIEntities, PlatfromIntake>
    {
        public int? GetSubTrackIDFromPlatFormIntakeID (int ? platformintakeid)
        {
            var platformIntake = FindobjBy(a => a.PlatformIntakeID== platformintakeid);
            return platformIntake.SubTrackID;
        }

    }
}
