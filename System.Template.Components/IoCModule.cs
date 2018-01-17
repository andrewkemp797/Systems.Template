using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Template.Component.Components;
using System.Template.Components.Interfaces;
using System.Text;
using System.Threading.Tasks;

namespace System.Template.Components
{
    public class IoCModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PingComponent>().As<IPingComponent>();
        }
    }
}
