using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vocap.Domain.AggregatesModel.ListeningAggreate;
using Vocap.Domain.AggregatesModel.VocabularyAggreate;

namespace Vocap.Infrastructure.EntityConfigurations
{
    public class ListeningTypeEntityConfiguration : IEntityTypeConfiguration<Listening>
    {
        public void Configure(EntityTypeBuilder<Listening> builder)
        {
            builder.ToTable("listening");
            builder.Ignore(v => v.DomainEvents);

            // VietnamMeaning value object persisted as owned entity type supported since EF Core 2.0
            // EF Core has the concept of Owned Entity Types, which can be used to implement DDD value types

        }
    }
}
