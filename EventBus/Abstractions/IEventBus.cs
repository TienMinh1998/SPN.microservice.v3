using EventBus.Events;

namespace EventBus.Abstractions;

public interface IEventBus
{
    Task PublishAsync(BaseMessage message, string queueName);
}
