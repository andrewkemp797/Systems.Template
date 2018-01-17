using System;
using System.Collections.Generic;
using System.Linq;
using System.Template.Common.Models;
using System.Text;
using System.Threading.Tasks;

namespace System.Template.Components.Interfaces
{
    public interface IPingComponent
    {
        Task<Ping> GetPong();
    }
}
