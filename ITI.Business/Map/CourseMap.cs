using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Business.Map
{
    public partial class CourseMap
    {
        

        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public Nullable<int> CategoryID { get; set; }

       
      //  public virtual ICollection<CourseManualMap> CourseManuals { get; set; }
    }
}
