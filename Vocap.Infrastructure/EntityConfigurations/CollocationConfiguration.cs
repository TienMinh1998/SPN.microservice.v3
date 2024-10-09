using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vocap.Domain.AggregatesModel.CollocationsAggreate;
using Vocap.Domain.AggregatesModel.ListeningAggreate;

namespace Vocap.Infrastructure.EntityConfigurations
{
    public class CollocationConfiguration : IEntityTypeConfiguration<Collocation>
    {
        public void Configure(EntityTypeBuilder<Collocation> builder)
        {
            builder.ToTable("collocation");
            builder.Ignore(v => v.DomainEvents);
        }
    }
}
