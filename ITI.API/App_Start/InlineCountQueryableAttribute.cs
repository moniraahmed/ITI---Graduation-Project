using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Web.Http.OData;
using System.Web.Http.OData.Extensions;

namespace ITI.Data
{
    class InlineCountQueryableAttribute : EnableQueryAttribute
    {
        private static MethodInfo _createPageResult =
            typeof(InlineCountQueryableAttribute)
            .GetMethods(BindingFlags.Static | BindingFlags.NonPublic)
            .Single(m => m.Name == "CreatePageResult");

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);

            HttpRequestMessage request = actionExecutedContext.Request;
            HttpResponseMessage response = actionExecutedContext.Response;

            IQueryable result;
            if (response.IsSuccessStatusCode
                && response.TryGetContentValue<IQueryable>(out result))
            {
                long? inlineCount = request.ODataProperties().TotalCount;//.GetInlineCount();
                if (inlineCount != null)
                {
                    actionExecutedContext.Response = _createPageResult.MakeGenericMethod(result.ElementType).Invoke(
                        null, new object[] { request, request.ODataProperties().TotalCount, request.ODataProperties().NextLink, result }) as HttpResponseMessage;
                }
            }
        }

        internal static HttpResponseMessage CreatePageResult<T>(HttpRequestMessage request, long? count, Uri nextpageLink, IEnumerable<T> results)
        {
            return request.CreateResponse(HttpStatusCode.OK, new PageResult<T>(results, nextpageLink, count));
        }

    }
}
