using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;


namespace EventBus.Abstractions
{
    public abstract class RBMQBaseComsumer : BackgroundService
    {
        protected abstract string GetQueueName();
        private IConnection _connection;
        protected IModel _channel;

        public RBMQBaseComsumer(string queueName, string hostName, string userName, string passWord)
        {
            var factory = new ConnectionFactory
            {
                HostName = hostName,
                UserName = userName,
                Password = passWord
            };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: queueName, false, false, false, arguments: null);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += OnMessageReceived;

            _channel.BasicConsume(queue: GetQueueName(),
                      autoAck: false,
                      consumer: consumer);
            return Task.CompletedTask;
        }

        private void OnMessageReceived(object? sender, BasicDeliverEventArgs e)
        {
            _channel?.Close();
            _connection?.Close();
            base.Dispose();
        }
    }
}
