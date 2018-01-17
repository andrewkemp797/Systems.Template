using System;
using System.Collections.Generic;
using System.Linq;
using System.Template.Common.Models;
using System.Template.Components.Interfaces;
using System.Template.Repository.Interfaces;
using System.Text;
using System.Threading.Tasks;

namespace System.Template.Component.Components
{
    public class PingComponent : IPingComponent
    {
        private IRepository<Ping> _repo;

        public PingComponent(IRepository<Ping> repo)
        {
            _repo = repo;
        }

        public async Task<Ping> GetPong()
        {
            return await _repo.SelectByID(1);
        }
    }
}
