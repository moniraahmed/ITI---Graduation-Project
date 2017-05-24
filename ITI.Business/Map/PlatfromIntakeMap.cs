using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Business.Map
{
    public partial class PlatfromIntakeMap
    {
       

        public int PlatformIntakeID { get; set; }
        public Nullable<int> BranchID { get; set; }
        public Nullable<int> SubTrackID { get; set; }
        public Nullable<int> ProgramIntakeID { get; set; }
        public Nullable<int> OwnedBy { get; set; }
        public string GraduateProfile { get; set; }

        public virtual subTrackMap subTrack { get; set; }
     
        public virtual ICollection<StudentBasicDataMap> StudentBasicDatas { get; set; }
       
        public virtual ICollection<TrackManualMap> TrackManuals { get; set; }
        public virtual BranchMap Branch { get; set; }
      //  public virtual ProgramIntakeMap ProgramIntake { get; set; }
      
        //public virtual ICollection<TrackManager> TrackManagers { get; set; }
     
        //public virtual ICollection<TrackSupervisor> TrackSupervisors { get; set; }
    }
}
