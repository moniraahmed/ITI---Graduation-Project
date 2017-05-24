using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ITI.Business.Map;
using ITI.Business.Manager;
using System.Web.Http.OData.Query;

namespace ITI.API.Controllers
{
    [RoutePrefix("api/Intak")]
    public class IntakController : ApiController
    {
        [Route("GetIntak")]
        [HttpGet]
        // GET: api/Intak
        public IntakeMap Get(int id)
        {
            return new IntakManager().getIntak(id);

        }
    }
}
