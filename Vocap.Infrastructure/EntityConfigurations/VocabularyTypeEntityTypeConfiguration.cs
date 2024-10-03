using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vocap.Domain.AggregatesModel.VocabularyAggreate;
using static Hola.Core.Common.MessagingConstants;

namespace Vocap.Infrastructure.EntityConfigurations
{
    public class VocabularyTypeEntityTypeConfiguration : IEntityTypeConfiguration<Vocabulary>
    {
        public void Configure(EntityTypeBuilder<Vocabulary> builder)
        {
            builder.ToTable("vocabularies");
            builder.Ignore(v => v.DomainEvents);

            // VietnamMeaning value object persisted as owned entity type supported since EF Core 2.0
            // EF Core has the concept of Owned Entity Types, which can be used to implement DDD value types
            builder.OwnsOne(x => x.VietnamMeaning);
            builder.OwnsOne(x => x.CamVocabulary);
        }
    }
}
