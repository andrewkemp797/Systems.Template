using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Template.ActorSystem.Messages
{
    public class PingMessages
    {
        public class Ping
        {
            private Ping()
            {

            }

            public static Ping Instance()
            {
                return new Ping();
            }
        }

        public class Pong
        {
            public System.Template.Common.Models.Ping Ping { get; set; }

            private Pong(System.Template.Common.Models.Ping ping)
            {
                Ping = ping;
            }

            public static Pong Instance(System.Template.Common.Models.Ping ping)
            {
                return new Pong(ping);
            }
        }
    }
}
