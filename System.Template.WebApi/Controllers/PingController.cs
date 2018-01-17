using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Template.ActorSystem;
using System.Template.ActorSystem.Messages;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace System.Template.WebApi//.Controllers
{
    public class PingController : ApiController
    {
        private IActorSystemShell _actorSystem;

        public PingController(IActorSystemShell actorSystem)
        {
            _actorSystem = actorSystem;
        }

        [HttpGet]
        public async Task<string> Ping()
        {
            var response = await _actorSystem.PingActor.Ask<PingMessages.Pong>(PingMessages.Ping.Instance(),
            TimeSpan.FromSeconds(10));

            return response.Ping.Response;
            //return "Pong";
        }
    }
}
