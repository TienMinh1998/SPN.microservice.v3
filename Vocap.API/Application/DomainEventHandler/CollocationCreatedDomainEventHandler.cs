using Vocap.API.Application.Commands;
using Vocap.Domain.Events;
using static Hola.Core.Common.Constants;

namespace Vocap.API.Application.DomainEventHandler
{
    public class CollocationCreatedDomainEventHandler : INotificationHandler<CollocationCreatedDomainEvent>
    {
        private readonly IMediator mediator;
        private ILogger<CollocationCreatedDomainEventHandler> _logger;
        public CollocationCreatedDomainEventHandler(IMediator mediator, ILogger<CollocationCreatedDomainEventHandler> logger)
        {
            this.mediator = mediator;
            _logger = logger;
        }

        public async Task Handle(CollocationCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            var createdCommand = new CreateVocabularyCommand(notification.LeftVocabulary, $"from collocation {notification.LeftVocabulary} {notification.RightVocabulary}");
            var updateResult = await mediator.Send(createdCommand);
            var createdCommand2 = new CreateVocabularyCommand(notification.RightVocabulary, $"from collocation {notification.LeftVocabulary} {notification.RightVocabulary}");
            var updateResult2 = await mediator.Send(createdCommand2);
        }
    }
}
