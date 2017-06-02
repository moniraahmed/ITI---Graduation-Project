using ITI.Business;
using ITI.Business.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace ITI.API.Controllers
{
    [System.Web.Http.RoutePrefix("api/Complaints")]
    public class Complaints_CategoriesController :ApiController
    {
        // GET: Complaints

        [System.Web.Http.Route("GetCategories")]
        [System.Web.Http.HttpGet]
        public IEnumerable<Complain_CategoryMap> GetAllCategories()
        {

            var m=new Complaints_CategoriesManager().GetComplaintsCategories().ToList();
            return m;
               
        }
       

    }
}