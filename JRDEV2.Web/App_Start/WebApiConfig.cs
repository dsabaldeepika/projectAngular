using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using System.Net.Http.Formatting;

namespace JRDEV2.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            var JsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            // Web API configuration and services
            // Makes it go through Bearer Token Authentication
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "UsersApi",
                routeTemplate: "api/v1/Users/{id}",
                defaults: new { controller = "apiUsers", id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "JobsApi",
                routeTemplate: "app/api/v1/Jobs/{id}",
                defaults: new { controller = "apiJobs", id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "JobSearchApi",
                routeTemplate: "app/api/v1/JobSearch/{id}",
                defaults: new { controller = "apiJobSearch", id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "SearchApi",
                routeTemplate: "app/api/v1/Search/{query}",
                defaults: new { controller = "apiSearch", query = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "MessagesApi",
                routeTemplate: "app/api/v1/Messages/{id}",
                defaults: new { controller = "apiMessages", id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                 name: "JobStatusApi",
                 routeTemplate: "app/api/v1/JobStatus/{id}",
                 defaults: new { controller = "apiJobStatus", id = RouteParameter.Optional }
             );
            config.Routes.MapHttpRoute(
                name: "ClicksApi",
                routeTemplate: "app/api/v1/Clicks/{id}",
                defaults: new { controller = "apiClicks", id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "CompanyApi",
                routeTemplate: "app/api/v1/Company/{id}",
                defaults: new { controller = "apiCompany", id = RouteParameter.Optional }
            );
            //DLR 
            config.Routes.MapHttpRoute(
                name: "ResumeApi",
                routeTemplate: "app/api/v1/Resumes/{id}",
                defaults: new { controller = "apiResumes", id = RouteParameter.Optional }
            );
            //DLR added route for JobCart Save Jobs
            config.Routes.MapHttpRoute(
                name: "SavedJobApi",
                routeTemplate: "app/api/v1/SavedJob/{id}",
             //   defaults: new { controller = "apiTalentProfile", id = RouteParameter.Optional }
            defaults: new { controller = "apiSavedJob", id = RouteParameter.Optional }
            );
            //DLR 
            config.Routes.MapHttpRoute(
                name: "SaveAllJobsApi",
                routeTemplate: "app/api/v1/Application/{id}",
                defaults: new { controller = "apiApplication", id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "JobsAppliedApi",
                routeTemplate: "app/api/v1/JobsApplied/{id}",
                defaults: new { controller = "apiJobApplied", id = RouteParameter.Optional }
            );
            //config.Routes.MapHttpRoute(
            //    name: "JobsAppliedApi",
            //    routeTemplate: "app/api/v1/JobsApplied/{id}",
            //    defaults: new { controller = "apiSavedJob", id = RouteParameter.Optional }
            //);
            config.Routes.MapHttpRoute(
                name: "TalentApi",
                routeTemplate: "app/api/v1/Talent/{id}",
                defaults: new { controller = "apiTalentProfile", id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "RegisterApi",
                routeTemplate: "api/Account/{id}",
                defaults: new { controller = "Account", id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
            name: "ApplicationApi",
            routeTemplate: "app/api/v1/Application/{id}",
            defaults: new { controller = "apiApplication", id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
    name: "DefaultApi",
    routeTemplate: "api/{controller}/{id}",
    defaults: new { id = RouteParameter.Optional }
);

        }
    }
}
