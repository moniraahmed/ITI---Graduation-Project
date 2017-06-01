using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using ITI.Business.Manager;
using ITI.Data;
using ITI.Data.DBmodel;
using System.Web.Http.OData.Query;
using System.Web.Http.OData;
using ITI.Business.Map;
using ITI.Business;

namespace ITI.API.Controllers
{
    [RoutePrefix("api/Employees")]
    public class EmployeeController : ApiController
    {
        [Route("GetEmployee1")]
        [HttpGet]
        public IEnumerable<EmployeeMap> Get()
        {

            return new EmployeeManager().Getemp().ToList();

        }
        //[Route("gettoken")]
        //[HttpGet]
        //public string gettoken()
        //{
        //    var response = GetToken();
        //    string acctoken = "AccessToken : " + response.AccessToken + " IdentityToken : " + response.IdentityToken;
        //    return acctoken;

        //}
        [Route("GetEmployee")]
        [HttpGet]
        //  [InlineCountQueryable]
        public IEnumerable<EmployeeMap> Get(ODataQueryOptions<EmployeeMap> options)
        {
            return new EmployeeManager().Getemp().TOOData(options, this);
            //ODataQuerySettings settingsodata = new ODataQuerySettings()
            //{
            //    PageSize = 10

            //};

            //IQueryable results = options.ApplyTo(employees, settingsodata);

            //return new PageResult<Employee>(
            //    results as IEnumerable<Employee>,
            //   this.Request.GetNextPageLink(),
            //   this.Request.GetInlineCount());
            ////return new EmployeeManager().getemp(options,this).ToList();

        }
        [Route("GetEmployee/{id}")]
        [HttpGet]
        public EmployeeMap Get(int id)
        {
            return new EmployeeManager().Getemp(id);
        }
        [Route("GetEmployee/{username}/{pass}")]
        [HttpGet]
        public EmployeeMap Get(string username, string pass)
        {
            return new EmployeeManager().Getemp(username, pass);

        }
        //static void CallApi(TokenResponse response)
        //{
        //    var client = new HttpClient();
        //    client.SetBearerToken(response.AccessToken);

        //  //  Console.WriteLine(client.GetStringAsync("http://localhost:44334/test").Result);
        //}

        //static TokenResponse GetToken()
        //{
        //    var client = new TokenClient(
        //        "https://localhost:44333/connect/token",
        //        "testclient",
        //        "F621F470-9731-4A25-80EF-67A6F7C5F4B8");

        //    return client.RequestResourceOwnerPasswordAsync("test", "123456", "test").Result;
        //}
        //change return type to complaint
        [Route("ShowComplaints/{id}")]
        [HttpGet]
        public IEnumerable<Student_ComplaintsMap> ShowComplaints(int id)
        {
            var Emp = new EmployeeManager().Getemp(id);
            if (Emp.TypeID == 1)//Track Supervisor
            {
                int? platformintakeid = new TrackSupervisorManager().GetPlatformintakeOfSupervisor(Emp.EmployeeID);
                var stds = new StudentManager().GetStudentInSubtrack(platformintakeid);
                List<Student_ComplaintsMap> allcomp = new List<Student_ComplaintsMap>();
                foreach (var s in stds)
                {

                    allcomp.AddRange(new ComplaintManager().GetStudentComplaintsatStageOne(s.StudentID));

                }

                return allcomp;
            }
            else if (Emp.TypeID == 4)//Track Manager
            {
                //missing job to insert stage2
                IEnumerable<TrackManager> Trackmanagerlist = new TrackManagerManager().GetPlatformintakeOfManager(Emp.EmployeeID);
                List<int?> platformids = new List<int?>();
                foreach (var p in Trackmanagerlist)
                {
                    platformids.Add(p.PlatformIntakeID);
                }
                List<StudentBasicDataMap> stds = new List<StudentBasicDataMap>();
                foreach (var p in platformids)
                {
                    stds.AddRange(new StudentManager().GetStudentInSubtrack(p));
                }
                List<Student_ComplaintsMap> allcomp = new List<Student_ComplaintsMap>();
                foreach (var s in stds)
                {

                    allcomp.AddRange(new ComplaintManager().GetStudentComplaintsatStageTwo(s.StudentID));

                }
                return allcomp;

            }
            else if (Emp.TypeID == 13)//9 Month Manager (Eng/Sherif Sharaf)
            {
                var stds = new StudentManager().GetAll();
                List<Student_ComplaintsMap> allcomp = new List<Student_ComplaintsMap>();
                foreach (var s in stds)
                {

                    allcomp.AddRange(new ComplaintManager().GetStudentComplaintsatStageThree(s.StudentID));

                }
                return allcomp;
                //best performance
                //var complaints = new ComplaintManager().GetAllComplaints();
                //List<Student_ComplaintsMap> allcomp = new List<Student_ComplaintsMap>();
                //foreach (var c in complaints)
                //{

                //    allcomp.Add(new ComplaintManager().GetStudentComplaintsatStageThree1(c.ID));

                //}
                //return allcomp;


            }
            else if (Emp.TypeID == 19) //Chairman Assistant For Training (Eng/Amr EL-shafie)
            {
                var stds = new StudentManager().GetAll();
                List<Student_ComplaintsMap> allcomp = new List<Student_ComplaintsMap>();
                foreach (var s in stds)
                {

                    allcomp.AddRange(new ComplaintManager().GetStudentComplaintsatStageFour(s.StudentID));

                }
                return allcomp;
            }

            else
            {
                return null;
            }
        }

        [Route("MonitorComplaints/{id}")]
        [HttpGet]
        public IEnumerable<Student_ComplaintsMap> MonitorComplaints(int id)
        {

            var Emp = new EmployeeManager().Getemp(id);

            if (Emp.TypeID == 4) //Track Manager
            {
                var allcomp = new ComplaintManager().GetStudentComplaintsatBeforeStageTwo();
                return allcomp;

            }

            else if (Emp.TypeID == 13) //9 Month Manager (Eng/Sherif Sharaf)
            {
                var allcomp = new ComplaintManager().GetStudentComplaintsatBeforeStageThree();
                return allcomp;

            }
            else if (Emp.TypeID == 19) //Chairman Assistant For Training (Eng/Amr EL-shafie)
            {
                var allcomp = new ComplaintManager().GetStudentComplaintsatBeforeStageFour();
                return allcomp;
            }
            else if (Emp.TypeID==3)
            {
                var allcomp = new ComplaintManager().GetStudentComplaintsatAllStages();
                return allcomp;
            }

            else
            {
                return null;
            }
        }
    }
   
   
}
