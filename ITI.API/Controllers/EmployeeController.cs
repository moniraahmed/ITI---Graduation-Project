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
        public  IEnumerable<EmployeeMap> Get(ODataQueryOptions<EmployeeMap> options)
        {
            return new EmployeeManager().Getemp().TOOData(options,this);
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
    }
   
}
