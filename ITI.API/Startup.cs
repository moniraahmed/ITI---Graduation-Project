using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using System.Web.Http.Owin;
using System.Web.Http.Controllers;
using System.Web.Http.OData.Extensions;
using ITI.Data;
using System.Web.Http.OData.Batch;
using Microsoft.Data.Edm;
using System.Web.Http.OData.Builder;
using ITI.Data.DBmodel;
using ITI.Business.Map;

[assembly: OwinStartup(typeof(ITI.API.Startup))]

namespace ITI.API
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            ConfigureAuth(app);
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            HttpConfiguration config = new HttpConfiguration();
            //ConfigureOAuth(app);
            ConfigureAuth(app);
            WebApiConfig.Register(config);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            config.Filters.Add(new AuthorizeAttribute());
            app.UseWebApi(config);
            config.AddODataQueryFilter(new InlineCountQueryableAttribute());
            AutoMapperConfiguration.Configure();
           
        }
      
    }
}
