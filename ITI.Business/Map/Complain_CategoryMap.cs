using ITI.Data.DBmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Business.Map
{
    public partial class Complain_CategoryMap
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string No_Of_Stages { get; set; }
       // public virtual ICollection<Student_Complaints> Student_Complaints { get; set; }

    }
}

