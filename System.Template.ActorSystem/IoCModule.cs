using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Template.ActorSystem.Actors;
using System.Text;
using System.Threading.Tasks;

namespace System.Template.ActorSystem
{
    public class IoCModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<ActorSystemShell>().As<IActorSystemShell>();
            builder.RegisterType<PingActor>();
        }
    }
}
