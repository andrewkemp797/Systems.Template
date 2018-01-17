using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Template.ActorSystem;
using System.Template.Common.DI;
using System.Template.Common.Models;
using System.Template.Repository;
using System.Template.Repository.Interfaces;
using System.Template.Repository.Repositories;
using System.Template.WebApi;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace System.Template.WindowsService
{
    class Program
    {
        static void Main(string[] args)
        {
            IoC.Bootstrapping(builder =>
            {
                IActorSystemSettings actorSettings = new ActorSystemSettings()
                {
                    SystemName = "testactorsystem"
                };
                builder.RegisterInstance(actorSettings).As<IActorSystemSettings>();

                IActorSystemShell shell = new ActorSystemShell(actorSettings);
                builder.RegisterInstance(shell);

                //register repository context
                var context = new DatabaseContext();
                builder.RegisterInstance(context);
            });

            HostFactory.Run(x =>
            {
                x.Service<HostService>(s =>
                {
                    s.ConstructUsing(name => new HostService());
                    s.WhenStarted(sn => sn.Start());
                    s.WhenStopped(sn => sn.Stop());
                });
                x.RunAsLocalSystem();
                x.SetDescription("Sample Service");
                x.SetDisplayName("Sample Service");
                x.SetServiceName("Sample Service");
            });
        }
    }
}
