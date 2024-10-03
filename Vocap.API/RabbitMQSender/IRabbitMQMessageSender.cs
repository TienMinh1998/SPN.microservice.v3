using EventBus.Events;

namespace Vocap.API.RabbitMQSender
{
    public interface IRabbitMQMessageSender
    {
        Task SendMessageAsync(BaseMessage baseMessage, string queueName);
    }
}
