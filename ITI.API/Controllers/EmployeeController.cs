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


namespace ITI.API.Controllers
{
    [RoutePrefix("api/Employee")]
    public class EmployeeController : ApiController
    {
        [Route("GetEmployee")]
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            
            return new EmployeeManager().getemp().ToList();

        }
        //[Route("gettoken")]
        //[HttpGet]
        //public string gettoken()
        //{
        //    var response = GetToken();
        //    string acctoken = "AccessToken : " + response.AccessToken + " IdentityToken : " + response.IdentityToken;
        //    return acctoken;

        //}
        [Route("GetEmployee2")]
        [HttpGet]
      //  [InlineCountQueryable]
        public  IEnumerable<Employee> Get2(ODataQueryOptions<Employee> options)
        {
            IEnumerable<Employee> employees = new EmployeeManager().getemp().TOOData(options,this);
            return employees ;
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
