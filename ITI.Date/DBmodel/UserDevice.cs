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
    
    public partial class UserDevice
    {
        public int UserDevicesID { get; set; }
        public string DevicesOS { get; set; }
        public string DevicesOsVersion { get; set; }
        public string DevicesID { get; set; }
        public Nullable<int> EmployeeID { get; set; }
        public Nullable<int> StudentID { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual StudentBasicData StudentBasicData { get; set; }
    }
}
