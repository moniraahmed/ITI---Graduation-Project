using ITI.Business.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ITI.Business.Manager;
using System.Web.Http.OData.Query;
using System.Web.Http;


namespace ITI.API.Controllers
{
    [RoutePrefix("api/students")]
    public class StudentController : ApiController
    {
        [Route("Getstudent")]
        [HttpGet]
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

    }
}