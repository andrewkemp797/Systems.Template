using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Template.ActorSystem
{
    public interface IActorSystemShell
    {
        IActorRef PingActor { get; set; }

        void Start();
        void Stop();
    }
}
