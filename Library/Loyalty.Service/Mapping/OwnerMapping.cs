using Loyalty.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loyalty.Service.Mapping
{
    public class OwnerMapping : IEntityTypeConfiguration<Owner>
    {
        public void Configure(EntityTypeBuilder<Owner> builder)
        {
            builder.HasMany<Store>(x => x.Stores)
                .WithOne(x => x.Owner)
                .HasForeignKey(x => x.OwnerId);
        }
    }
}
