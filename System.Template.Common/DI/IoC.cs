using Autofac;
using Autofac.Builder;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace System.Template.Common.DI
{
    public static class IoC
    {
        public static IContainer Container { get; set; }

        public static void Bootstrapping(Action<ContainerBuilder> builderConfig)
        {
            //new builder instance
            var builder = new ContainerBuilder();
            builderConfig.Invoke(builder);
            Container = builder.Build();

            builder = new ContainerBuilder();
            builder.ScanAssembly();

            builder.Update(Container);
        }
    }
}
