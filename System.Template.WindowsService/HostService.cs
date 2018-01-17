using System;
using Autofac;
using System.Collections.Generic;
using System.Linq;
using System.Template.Common.DI;
using System.Text;
using System.Threading.Tasks;
using System.Template.WebApi;
using System.Template.ActorSystem;

namespace System.Template.WindowsService
{
    public class HostService
    {
        //when windows service statrts
        public void Start()
        {
            try
            {
                //start the web app
                IoC.Container.Resolve<IApiShell>().Start();  
                IoC.Container.Resolve<IActorSystemShell>().Start();
                
            }
            catch (Exception ex)
            {
                //TODO: log exception. Need to implement logging
            }
        }

        //when windows service stops
        public void Stop()
        {
            IoC.Container.Resolve<IActorSystemShell>().Stop();
        }
    }
}
