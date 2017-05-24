using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ITI.Data.DBmodel;
using ITI.Business.Manager;
using System.Web.Http.OData.Query;
using ITI.Business.Map;


namespace ITI.API.Controllers
{
    [RoutePrefix("api/programs")]
  //  [Authorize]
    public class programsController : ApiController
    {
        [Route("Getprogram")]
        [HttpGet]
        // GET: api/programs
        public IEnumerable<programMap> Get(ODataQueryOptions<programMap> options)
        {
            return new programManager().getprogrm().TOOData(options, this);
             
        }
        [Route("Getprogram")]
        [HttpGet]
        // GET: api/programs/5
        public programMap Get(int id)
        {
            return new programManager().getprogrm(id);

        }


    }
}
