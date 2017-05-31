using ITI.Data.DBmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Business.Map
{
    public partial class Student_ComplaintsMap
    {
        public int ID { get; set; }
        public string Body { get; set; }
        public string Subject { get; set; }
        public string Type { get; set; }
        public int FK_Student_Id { get; set; }
        public int FK_Category_Id { get; set; }
       // public virtual Complain_Category Complain_Category { get; set; }
      //  public virtual ICollection<Complaint_Stage> Complaint_Stage { get; set; }
      //  public virtual StudentBasicData StudentBasicData { get; set; }

    }
}
