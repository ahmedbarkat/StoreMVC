using Safoa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Safoa.DAL
{
    public class SafoaInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<SafoaContext>
    {
        protected override void Seed(SafoaContext context)
        {
            var engines = new List<Engine>
            {
            new Engine{EngineNum="Carson",CertificateNum="Alexander",VoucherNum="Test Engine",Date=DateTime.Parse("2005-09-01"),Name="Test Engine"},

            };

            engines.ForEach(s => context.Engines.Add(s));
            context.SaveChanges();


        }
    }
}