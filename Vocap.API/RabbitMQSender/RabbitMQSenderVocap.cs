using RabbitMQ.Client;
using System.Text.Json;
using System.Text;
using EventBus.Events;
using Vocap.API.RabbitMessage;
using Microsoft.Extensions.DependencyInjection;
using Polly.Registry;
using Polly;

namespace Vocap.API.RabbitMQSender
{
    public class RabbitMQSenderVocap : IRabbitMQMessageSender
    {
        private readonly string _hostName;
        private readonly string _password;
        private readonly string _userName;
        private IConnection _connection;
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<RabbitMQSenderVocap> _logger;


        public RabbitMQSenderVocap(IServiceProvider serviceProvider, ILogger<RabbitMQSenderVocap> logger)
        {
            _hostName = "localhost";
            _password = "guest";
            _userName = "guest";
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        public async Task SendMessageAsync(BaseMessage message, string queueName)
        {
            // Retrieve a ResiliencePipelineProvider that dynamically creates and caches the resilience pipelines
            var pipelineProvider = _serviceProvider.GetRequiredService<ResiliencePipelineProvider<string>>();
            // Retrieve your resilience pipeline using the name it was registered with
            ResiliencePipeline pipeline = pipelineProvider.GetPipeline("sla_pipeline");

            await pipeline.ExecuteAsync(async token =>
              {
                  // Your custom logic goes here
                  if (ConnectionExists())
                  {
                      using var channel = _connection.CreateModel();
                      channel.QueueDeclare(queue: queueName, false, false, true, arguments: null);
                      byte[] body = GetMessageAsByteArray(message);
                      channel.BasicPublish(
                          exchange: "", routingKey: queueName, basicProperties: null, body: body);
                  }

              });
        }

        private byte[] GetMessageAsByteArray(BaseMessage message)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            var json = JsonSerializer.Serialize((PaymentMessage)message, options);
            var body = Encoding.UTF8.GetBytes(json);
            return body;
        }

        private void CreateConnection()
        {
            try
            {
                var factory = new ConnectionFactory
                {
                    HostName = _hostName,
                    UserName = _userName,
                    Password = _password
                };
                _connection = factory.CreateConnection();
            }
            catch (Exception)
            {
                //Log exception
                throw;
            }
        }

        private bool ConnectionExists()
        {
            if (_connection != null) return true;
            CreateConnection();
            return _connection != null;
        }

    }
}
