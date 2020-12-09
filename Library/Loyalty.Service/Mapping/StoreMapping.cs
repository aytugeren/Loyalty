using Loyalty.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loyalty.Service.Mapping
{
    public class StoreMapping : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.Property(x => x.Point).HasDefaultValue(0);
        }
    }
}
