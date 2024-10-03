using Vocap.Domain.Events;

namespace Vocap.API.Application.DomainEventHandler
{
    public class AddEnglishVocabularyDomainEventHandler
        : INotificationHandler<AddEnglishVocabularyDomainEvent>
    {

        private ILogger<AddEnglishVocabularyDomainEventHandler> _logger;
        public AddEnglishVocabularyDomainEventHandler(ILogger<AddEnglishVocabularyDomainEventHandler> logger)
        {
            _logger = logger;
        }


        public async Task Handle(AddEnglishVocabularyDomainEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Add the vocabulary :{notification.Vocabulary} ");
        }
    }
}
