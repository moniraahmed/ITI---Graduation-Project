using ITI.Data.DBmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Business.Map
{
   public partial class EmployeeMap
    {
        public int EmployeeID { get; set; }
        public string InstructorName { get; set; }
        public int BranchID { get; set; }
        public string IPassword { get; set; }
        public string UserName2 { get; set; }
        public Nullable<int> PlatformID { get; set; }
        public Nullable<int> RoleID { get; set; }
        public Nullable<int> TypeID { get; set; }
        public string ArabicName { get; set; }
        public Nullable<int> CertificateID { get; set; }
        public Nullable<int> org_branchid { get; set; }
        public Nullable<int> StatusID { get; set; }
        public Nullable<int> PositionID { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public Nullable<int> IntakeID { get; set; }
        public Nullable<int> Flag { get; set; }
        public string PositionName { get; set; }
        public Nullable<int> EmpStatus { get; set; }
        public System.Guid msrepl_tran_version { get; set; }
          public Nullable<int> empno { get; set; }
        public Nullable<int> cat { get; set; }

       // public virtual ICollection<UserDevice> UserDevices { get; set; }
        public virtual ICollection<TrackSupervisor> TrackSupervisors { get; set; }
        public virtual ICollection<TrackManager> TrackManagers { get; set; }


    }
}
