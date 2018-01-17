using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Template.Common.Models;
using System.Text;
using System.Threading.Tasks;

namespace System.Template.Repository.Interfaces
{
    public interface IDatabaseContext 
    {
        IDbSet<Ping> Ping { get; set; }
    }
}
