using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Business.Map
{
    public partial class CourseManualMap
    {
       

        public int courseManualID { get; set; }
        public Nullable<int> CourseID { get; set; }
        public Nullable<int> totalGrade { get; set; }
        public Nullable<int> minGrade { get; set; }
        public Nullable<int> labsNumber { get; set; }
        public Nullable<int> lecturesNumber { get; set; }
        public Nullable<int> lech { get; set; }
        public Nullable<int> selfh { get; set; }
        public Nullable<int> labh { get; set; }
        public Nullable<int> credit { get; set; }
        public string coursenote { get; set; }
        public string swReq { get; set; }
        public string hwReq { get; set; }
        public string CourseCode { get; set; }
        public string CourseDescription { get; set; }
        public string CourseObjective { get; set; }
        public string CourseContent { get; set; }
        public Nullable<int> ProgramIntakeID { get; set; }

        public virtual CourseMap Course { get; set; }
       
       // public virtual ICollection<TrackManual> TrackManuals { get; set; }
    }
}
