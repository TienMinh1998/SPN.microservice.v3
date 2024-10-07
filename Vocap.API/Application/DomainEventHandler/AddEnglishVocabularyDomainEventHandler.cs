using Vocap.API.RabbitMessage;
using Vocap.API.RabbitMQSender;
using Vocap.Domain.Events;
using static Hola.Core.Common.Constants;

namespace Vocap.API.Application.DomainEventHandler
{
    public class AddEnglishVocabularyDomainEventHandler
        : INotificationHandler<AddEnglishVocabularyDomainEvent>
    {
        private IRabbitMQMessageSender _rabbitMessageSender;

        private ILogger<AddEnglishVocabularyDomainEventHandler> _logger;
        public AddEnglishVocabularyDomainEventHandler(ILogger<AddEnglishVocabularyDomainEventHandler> logger, IRabbitMQMessageSender rabbitMessageSender)
        {
            _logger = logger;
            _rabbitMessageSender = rabbitMessageSender;
        }

        public async Task Handle(AddEnglishVocabularyDomainEvent notification, CancellationToken cancellationToken)
        {
            // send message
            var message = new CreatedVocabularyMessage(notification.Vocabulary);
            await _rabbitMessageSender.SendMessageAsync<CreatedVocabularyMessage>(message);
            _logger.LogInformation($"Add the vocabulary :{notification.Vocabulary} ");
        }
    }
}
