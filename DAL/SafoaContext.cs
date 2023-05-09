using Safoa.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Safoa.DAL
{
    public class SafoaContext : DbContext
    {
        public SafoaContext() : base("Safoa") { }
        public DbSet<Engine> Engines { get; set; }
        public DbSet<SellOrder> SellOrders { get; set; }
        public DbSet<SellOrderItem> SellOrderItems { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserScopes> UserScopes { get; set; }

        public DbSet<Foundation> Foundations { get; set; }
        public DbSet<SystemMonitor> SystemMonitors { get; set; }


        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}