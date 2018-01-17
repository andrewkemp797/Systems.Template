using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Template.ActorSystem.Messages;
using System.Template.Common.Models;
using System.Template.Components.Interfaces;
using System.Text;
using System.Threading.Tasks;

namespace System.Template.ActorSystem.Actors
{
    public class PingActor : ReceiveActor
    {
        private IActorSystemSettings _settings;
        private IPingComponent _pingComponent; 

        public PingActor(IActorSystemSettings settings, IPingComponent pingComponent)
        {
            _settings = settings;
            _pingComponent = pingComponent;
            Become(Listening);
        }

        public void Listening()
        {
            Receive<PingMessages.Ping>(x =>
            {
                GetPongResponse();
            });
        }

        public void GetPongResponse()
        {
            Task.Run<PingMessages.Pong>(async () =>
            {
                try
                {
                    var pongResult = await _pingComponent.GetPong();
                    return PingMessages.Pong.Instance(pongResult);
                }
                catch (Exception ex)
                {
                    //log
                    return null;
                }
            }).PipeTo(Context.Sender);
        }
    }
}
