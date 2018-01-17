using System;
using Akka;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;
using Akka.DI.Core;
using System.Template.ActorSystem.Actors;
using Akka.DI.AutoFac;
using System.Template.Common.DI;

namespace System.Template.ActorSystem
{
    public class ActorSystemShell : IActorSystemShell
    {
        private IActorSystemSettings _settings;
        public static Akka.Actor.ActorSystem _system { get; set; }
        public IActorRef PingActor { get; set; }

        public ActorSystemShell(IActorSystemSettings settings)
        {
            _settings = settings;
        }

        public void Start()
        {
            _system = Akka.Actor.ActorSystem.Create(_settings.SystemName);

            // Create the dependency resolver
            IDependencyResolver resolver = new AutoFacDependencyResolver(IoC.Container, _system);

            PingActor = _system.ActorOf(_system.DI().Props<PingActor>(), ActorNames.PingActor);

            Console.WriteLine($"Starting actor system: {_settings.SystemName}");
        }

        public void Stop()
        {
            Console.WriteLine("Stopping actor system");
        }
    }
}
