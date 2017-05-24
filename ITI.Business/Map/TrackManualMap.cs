using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Business.Map
{
    public partial class TrackManualMap
    {
        public int TrackManualID { get; set; }
        public Nullable<int> CourseManualID { get; set; }
        public Nullable<int> PlatformIntakeID { get; set; }
        public Nullable<bool> IsElective { get; set; }
        public Nullable<int> ElecetiveGroupID { get; set; }

        public virtual CourseManualMap CourseManual { get; set; }
       // public virtual PlatfromIntake PlatfromIntake { get; set; }
    }
}
