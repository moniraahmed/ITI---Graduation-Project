using ITI.Data.DataRepositoy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.OData;
using System.Web.Http.OData.Extensions;
using System.Web.Http.OData.Query;


namespace ITI.API
{
    public static class ApiDataRepository
    {
        public static IEnumerable<T> TOOData<T>(this IEnumerable<T> query,
                                            ODataQueryOptions<T> options,
                                            ApiController controller)
        {
            ODataQuerySettings settings = new ODataQuerySettings()
            {
                PageSize = 10

            };
            IQueryable results = options.ApplyTo(query.AsQueryable(), settings);

            return new PageResult<T>(
                results as IEnumerable<T>,
               controller.Request.ODataProperties().NextLink,
               controller.Request.ODataProperties().TotalCount).AsEnumerable();

        }
       
    }
}