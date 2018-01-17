using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Template.Common.Models;
using System.Template.Repository.Interfaces;
using System.Text;
using System.Threading.Tasks;

namespace System.Template.Repository
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DatabaseContext() : base("sqlConnection")
        {

        }

        public IDbSet<Ping> Ping { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
