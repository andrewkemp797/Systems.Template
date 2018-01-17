using Autofac;
using Autofac.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace System.Template.Common.DI
{
    public static class ContainerBuilderExtensions
    {
        public static void ScanAssembly(this ContainerBuilder builder, string searchPattern = "System.*.dll")
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            foreach (var assembly in Directory.GetFiles(path, searchPattern).Select(Assembly.LoadFrom))
            {
                builder.RegisterAssemblyModules(assembly);
            }
        }
    }
}
