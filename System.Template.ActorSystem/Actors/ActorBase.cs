using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Template.ActorSystem.Actors
{
    public abstract class ActorBase : ReceiveActor
    {
        public ActorBase()
        {

        }

        public abstract void HandleMessage(object message);

        public abstract void Listening();

        protected override void PreStart()
        {
            base.PreStart();

            Become(Listening);
        }
    }
}
