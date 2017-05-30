﻿using ITI.Business.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace ITI.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AutoMapperConfiguration.Configure();
        }

        protected void Application_BeginRequest()
        {
            if (Request.Headers.AllKeys.Contains("Origin") && Request.HttpMethod == "OPTIONS")
            {
                Response.Flush();
            }
        }
        //protected void Application_BeginRequest()
        //{
        //    if (Request.HttpMethod == "OPTIONS")
        //    {
        //        Response.StatusCode = (int)HttpStatusCode.OK;
        //        Response.AppendHeader("Access-Control-Allow-Origin", Request.Headers.GetValues("Origin")[0]);
        //        Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Accept");
        //        Response.AddHeader("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE");
        //        Response.AppendHeader("Access-Control-Allow-Credentials", "true");
        //        Response.End();
        //    }
        //}
    }
}
