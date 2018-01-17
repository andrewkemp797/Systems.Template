using Autofac;
using Autofac.Integration.WebApi;
using Microsoft.Owin.Hosting;
using Owin;
using Swashbuckle.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Template.Common.DI;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace System.Template.WebApi
{
    public class ApiShell : IApiShell
    {
        IDisposable _webApp;

        public void Start()
        {
            _webApp = WebApp.Start<Startup>("http://localhost:9090");
            Console.WriteLine($"Web server running at 'http://localhost:9090'");
        }

        public void Stop()
        {
            _webApp.Dispose();
        }

        internal class Startup
        {
            //Configure Web API for Self-Host
            public void Configuration(IAppBuilder app)
            {
                var config = new HttpConfiguration();

                //default route
                config.Routes.MapHttpRoute(
                    name: "DefaultApi",
                    routeTemplate: "api/{controller}/{id}",
                    defaults: new { id = RouteParameter.Optional });

                config
                  .EnableSwagger(c => c.SingleApiVersion("v1", "Swagger UI"))
                  .EnableSwaggerUi();

                app.UseWebApi(config);

                config.DependencyResolver = new AutofacWebApiDependencyResolver(IoC.Container);
            }
        }
    }
}
