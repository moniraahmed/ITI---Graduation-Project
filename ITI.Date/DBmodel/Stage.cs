//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ITI.Data.DBmodel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Stage
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Stage()
        {
            this.Complaint_Stage = new HashSet<Complaint_Stage>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public int FK_CategoryID { get; set; }
    
        public virtual Complain_Category Complain_Category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Complaint_Stage> Complaint_Stage { get; set; }
    }
}
