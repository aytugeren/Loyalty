using Loyalty.Core.Domain;
using Loyalty.Service.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loyalty.Service
{
    public class LoyaltyDbContext : DbContext
    {
        public LoyaltyDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = DESKTOP-VD01PB5\SQLEXPRESS; Database=Loyalty;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerMapping());
            modelBuilder.ApplyConfiguration(new CustomerStoreMapping());
            modelBuilder.ApplyConfiguration(new OwnerMapping());
            modelBuilder.ApplyConfiguration(new StoreMapping());
        }

        public DbSet<Customer> tblCustomer { get; set; }

        public DbSet<Store> tblStore { get; set; }

        public DbSet<CustomerStore> tblCustomerStore { get; set; }

        public DbSet<Owner> tblOwner { get; set; }
    }
}
