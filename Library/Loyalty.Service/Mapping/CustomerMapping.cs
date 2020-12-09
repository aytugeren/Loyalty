using Loyalty.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loyalty.Service.Mapping
{
    public class CustomerMapping : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(x => x.IsActive).HasDefaultValue(true);
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
            builder.Property(x => x.Point).HasDefaultValue(0);
            builder.Property(x => x.UpdatedTime).IsRequired(false);
            builder.Property(x => x.Password).IsRequired(false);

        }
    }
}
