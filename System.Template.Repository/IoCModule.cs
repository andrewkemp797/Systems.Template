using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Template.Common.Models;
using System.Template.Repository.Interfaces;
using System.Template.Repository.Repositories;
using System.Text;
using System.Threading.Tasks;

namespace System.Template.Repository
{
    public class IoCModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PingRepository>().As<IRepository<Ping>>();
        }
    }
}
