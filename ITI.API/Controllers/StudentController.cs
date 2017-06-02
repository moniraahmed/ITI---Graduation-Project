using ITI.Business.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ITI.Business.Manager;
using System.Web.Http.OData.Query;
using System.Web.Http;
using ITI.Business;
using ITI.Data.DBmodel;

namespace ITI.API.Controllers
{
    [RoutePrefix("api/students")]
    public class StudentController : ApiController
    {
        [Route("Getstudent")]
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.HttpGet]
        
        // GET: Student
        public IEnumerable<StudentBasicDataMap> Get(ODataQueryOptions<StudentBasicDataMap> options)
        {
            return new StudentManager().GetStudent().TOOData(options, this);

        }
   
        [Route("Getstudent/{id}")]
        [HttpGet]
        // GET: api/student/5
        public StudentBasicDataMap Get(int id)
        {
            return new StudentManager().GetStudent(id);

        }
        [Route("Getstudent/{username}/{pass}")]
        [HttpGet]
        // GET: api/
        public StudentBasicDataMap Get(string username,string pass)
        {
            return new StudentManager().GetStudent(username,pass);

        }
        [Route("AddComplaint/{id}")]
        [HttpPost]
        public int AddNewComplaint([FromBody]Student_Complaints newcomplaint)
        {
            new ComplaintManager().AddComplaint(newcomplaint);
            int NewComplaintID = newcomplaint.ID;
            int st_id = newcomplaint.FK_Student_Id;
            var s = new StudentManager().GetStudent(st_id);
            int? empid=  new TrackSupervisorManager().GetSupervisor(s.SubTrackID);
            Complaint_Stage newstage = new Complaint_Stage();
            newstage.Comolaint_Id = NewComplaintID;
            newstage.CategoryID = newcomplaint.FK_Category_Id;
            newstage.Stage_ID = 1;
            newstage.EnterDate = DateTime.Now.Date;
            int Stage_duration= new StageManager().GetDuration(newstage.Stage_ID, newstage.CategoryID);
            newstage.ExitDate = newstage.EnterDate.AddDays(Stage_duration);
            newstage.FK_EmployeeID = empid;
            new Complaint_StageManager().AddNewStage(newstage);
            return 1;

        }
        [Route("GetComplaints/{st_id}")]
        [HttpGet]
        public IEnumerable<Student_ComplaintsMap> GetComplaints(int st_id)
        {
           return new ComplaintManager().GetStudentComplaints(st_id);
        }


        [Route("GetStudentSubTrackName/{st_id}")]
        [HttpGet]
        public string GetStudentSubTrackName(int st_id)
        {
            int ? subtrackID = new StudentManager().GetSubtrackId(st_id);
            int? SubTrackIDFromPlatformIntakeID = new PlatfromIntakeManager().GetSubTrackIDFromPlatFormIntakeID(subtrackID);
            var SubTrackName = new subTrackManager().GetSubTrackName(SubTrackIDFromPlatformIntakeID);
            return SubTrackName;


        }

        [Route("GetCompliantEnterDate/{comp_id}/{catgry_id}")]
        [HttpGet]
        public DateTime GetCompliantEnterDate(int comp_id,int catgry_id)
        {

           return new Complaint_StageManager().GetEnterDate(comp_id,catgry_id);

        }






    }
}