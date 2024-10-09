using Microsoft.EntityFrameworkCore;
using Vocap.API.Application.Queries;
using Vocap.Domain.AggregatesModel.CollocationsAggreate;
using Vocap.Domain.AggregatesModel.ListeningAggreate;
using Vocap.Domain.AggregatesModel.VocabularyAggreate;
using Vocap.Infrastructure;
using Vocap.Infrastructure.Repositories;

namespace Vocap.API.Extensions
{
    public static class Extensions
    {
        public static void AppApplicationServices(this IHostApplicationBuilder builder)
        {
            var services = builder.Services;
            services.AddDbContext<VocabularyContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("vocapDb"));
            });

            builder.EnrichNpgsqlDbContext<VocabularyContext>();
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblyContaining(typeof(Program));

                //cfg.AddOpenBehavior(typeof(LoggingBehavior<,>));
                //cfg.AddOpenBehavior(typeof(ValidatorBehavior<,>));
                //cfg.AddOpenBehavior(typeof(TransactionBehavior<,>));
            });

            services.AddScoped<IVocabularyQueries, VocabularyQueries>();
            services.AddScoped<IVocabularyRepository, VocabularyRepository>();
            services.AddScoped<IListeningRepository, ListeningRepository>();
            services.AddScoped<ICollocationRepository, CollocationRepository>();


        }
    }
}
