
using Microsoft.AspNetCore.HttpsPolicy;
using Polly;
using Polly.Retry;
using Vocap.API.Extensions;
using Vocap.API.Middleware;

using Vocap.API.RabbitMQSender;
using Vocap.Infrastructure.Dapper;

namespace Vocap.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.AppApplicationServices();
            builder.Services.AddSingleton<IRabbitMQMessageSender, RabbitMQSenderVocap>();
            builder.Services.AddScoped<IDapper, DapperBase>();


            // add consumservice
            //  builder.Services.AddHostedService<RabbitComsumer>();

            // add Polly : 

            var optionsNoDelay = new RetryStrategyOptions
            {
                Delay = TimeSpan.FromSeconds(10)
            };
            var optionsDelayGenerator = new RetryStrategyOptions
            {
                MaxRetryAttempts = 5,
                DelayGenerator = static args =>
                {
                    var delay = args.AttemptNumber switch
                    {
                        0 => TimeSpan.Zero,
                        1 => TimeSpan.FromSeconds(1),
                        2 => TimeSpan.FromSeconds(5),
                        _ => TimeSpan.FromSeconds(10),
                    };

                    // This example uses a synchronous delay generator,
                    // but the API also supports asynchronous implementations.
                    return new ValueTask<TimeSpan?>(delay);
                }
            };
            var optionsDefaults = new RetryStrategyOptions();

            // get key from appsetting;
            var config = builder.Configuration.GetSection("Apikey");
            builder.Services.Configure<ApiKeys>(config);
            builder.Services.AddTransient<AuthMiddleware>();
            // apply the polly retry connection
            builder.Services.AddResiliencePipeline("sla_pipeline", builder =>
            {
                builder
                    .AddRetry(optionsDelayGenerator)
                    .AddTimeout(TimeSpan.FromSeconds(100));
            });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                        .AllowAnyOrigin() // Or specify origins using WithOrigins("http://example.com")
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

            var app = builder.Build();
            app.UseCors("CorsPolicy");

            var env = app.Environment;


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseMiddleware<ExceptionHandlingMiddleware>();
            app.UseMiddleware<AuthMiddleware>();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
