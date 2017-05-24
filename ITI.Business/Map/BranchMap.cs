using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Business.Map
{
    public partial class BranchMap
    {
        

        public int BranchID { get; set; }
        public string BranchName { get; set; }
        public string arabicname { get; set; }
       
        public Nullable<int> trainbranchid { get; set; }

       
     //   public virtual ICollection<PlatfromIntake> PlatfromIntakes { get; set; }
      //  public virtual TrainBranch TrainBranch { get; set; }
    }
}
