using Microsoft.AspNetCore.Connections;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace User.API.RabbitComsumner
{
    public class AddVocapComsumer : BackgroundService
    {
        private IConnection _connection;
        private RabbitMQ.Client.IModel _channel;
        public AddVocapComsumer()
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: "vocabularyqueue", false, false, true, arguments: null);
        }


        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (chanel, evt) =>
            {
                var body = evt.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine($" [x] recive {message}");
            };

            _channel.BasicConsume(queue: "vocabularyqueue",
                     autoAck: false,
                     consumer: consumer);
            return Task.CompletedTask;
        }
    }
}
