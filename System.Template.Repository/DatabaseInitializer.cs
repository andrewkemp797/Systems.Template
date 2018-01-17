using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Template.Common.Models;
using System.Text;
using System.Threading.Tasks;

namespace System.Template.Repository
{
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            context.Ping.Add(new Ping() { Response = "Pong" });
            context.SaveChanges();
        }
    }
}
