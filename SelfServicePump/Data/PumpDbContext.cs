using SelfServicePump.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SelfServicePump.Data
{
    public class PumpDbContext :DbContext
    {

        public PumpDbContext() : base("db_a06c09_studentdbEntities")
        {

        }

        public DbSet<Agents> Agents { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Transactions> Transactions { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
       

    }
}