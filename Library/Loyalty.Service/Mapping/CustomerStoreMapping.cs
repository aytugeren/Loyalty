using Loyalty.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loyalty.Service.Mapping
{
    public class CustomerStoreMapping : IEntityTypeConfiguration<CustomerStore>
    {
        public void Configure(EntityTypeBuilder<CustomerStore> builder)
        {
            builder.HasKey(x => new { x.CustomerId, x.StoreId });

            builder.Property(x => x.Id).HasDefaultValue(Guid.NewGuid());
            
            builder.HasOne<Store>(x => x.Store)
                .WithMany(x => x.CustomerStores)
                .HasForeignKey(x => x.StoreId);

            builder.HasOne<Customer>(x => x.Customer)
                .WithMany(x => x.CustomerStores)
                .HasForeignKey(x => x.CustomerId);
        }
    }
}
