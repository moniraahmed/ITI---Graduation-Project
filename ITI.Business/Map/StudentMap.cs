using ITI.Data.DBmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Business.Map
{
    public partial class StudentBasicDataMap
    {

        public int StudentID { get; set; }
        public string englishname { get; set; }
        public string arabicname { get; set; }
        public string ApplicationNo { get; set; }
        
        public string Email { get; set; }
        public int SubTrackID { get; set; }
        public string Barcode { get; set; }
      
        public string SchoolName { get; set; }
        public string Comment { get; set; }
        public string Username { get; set; }
        public string userpwd { get; set; }


        public virtual ICollection<UserDevice> UserDevices { get; set; }

        public virtual ICollection<PlatfromIntakeMap> StudentBasicDatas { get; set; }
    }
}
