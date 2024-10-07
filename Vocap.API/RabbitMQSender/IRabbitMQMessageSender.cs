using EventBus.Events;

namespace Vocap.API.RabbitMQSender
{
    public interface IRabbitMQMessageSender
    {
        Task SendMessageAsync<T>(BaseMessage baseMessage);
    }
}
