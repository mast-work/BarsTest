using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using BarsTest.Models;

namespace BarsTest.DAL
{
    public class BarsContext: DbContext
    {
        public DbSet<Item> Items { get; set; }

        public DbSet<Supp> Supps { get; set; }

        public DbSet<Delivery> Deliveryes { get; set; }
    }

    public class BarsDBInitializer : DropCreateDatabaseAlways<DbContext>//CreateDatabaseIfNotExists<DbContext>
    {
        protected override void Seed(DbContext context)
        {
            base.Seed(context);
        }
    }
}