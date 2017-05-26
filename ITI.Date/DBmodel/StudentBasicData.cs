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
    
    public partial class StudentBasicData
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StudentBasicData()
        {
            this.UserDevices = new HashSet<UserDevice>();
            this.Student_Complaints = new HashSet<Student_Complaints>();
            this.Student_Complaints1 = new HashSet<Student_Complaints>();
        }
    
        public int StudentID { get; set; }
        public string englishname { get; set; }
        public string arabicname { get; set; }
        public string ApplicationNo { get; set; }
        public Nullable<int> FK_UniversityFaculty_SpecializationId { get; set; }
        public Nullable<int> FK_FacultyId { get; set; }
        public Nullable<int> FK_SpecializationId { get; set; }
        public Nullable<int> FK_GraduationGradeId { get; set; }
        public string GraduationYear { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public int SubTrackID { get; set; }
        public string Barcode { get; set; }
        public Nullable<int> AccFlag { get; set; }
        public string Username { get; set; }
        public string userpwd { get; set; }
        public string imagepath { get; set; }
        public string RejectReason { get; set; }
        public Nullable<System.DateTime> DateOB { get; set; }
        public string gender { get; set; }
        public string Address { get; set; }
        public string IDNo { get; set; }
        public string GraduationGrade { get; set; }
        public Nullable<int> Rank { get; set; }
        public Nullable<int> Marital { get; set; }
        public Nullable<int> Military { get; set; }
        public Nullable<int> Language { get; set; }
        public string SocialAccount { get; set; }
        public string School { get; set; }
        public string GradProjIdea { get; set; }
        public string ProjGrade { get; set; }
        public string CertAqui { get; set; }
        public string PostGradStud { get; set; }
        public string AcadimicInst { get; set; }
        public string cvpath { get; set; }
        public string SchoolName { get; set; }
        public string Comment { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserDevice> UserDevices { get; set; }
        public virtual PlatfromIntake PlatfromIntake { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Student_Complaints> Student_Complaints { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Student_Complaints> Student_Complaints1 { get; set; }
    }
}
