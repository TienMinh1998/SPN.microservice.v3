using DatabaseCore.Domain.Questions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;

namespace DatabaseCore.Infrastructure.ConfigurationEntities
{
    internal class QuestionStandardConfiguration : IEntityTypeConfiguration<QuestionStandard>
    {
        public void Configure(EntityTypeBuilder<QuestionStandard> builder)
        {
            builder.ToTable("questionstandard", schema: "usr");
            builder.Ignore(x => x.DomainEvents);
        }
    }
}
